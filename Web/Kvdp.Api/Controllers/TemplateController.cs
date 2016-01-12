using Com.Gm.CodeFirstIOCDemo.BusinessLogic.Core.Models;
using Com.Gm.CodeFirstIOCDemo.Core;
using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Practices.Unity;

namespace Com.Gm.CodeFirstIOCDemo.Api
{
    public class TemplateController : ApiController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IContext _context;

        public TemplateController(IContext context)
        {
            _context = context;
        }

        public void ImportMilestones(string templateName, System.Web.HttpPostedFileBase[] xls)
        {
            if (xls.Length == 0)
            {
                _logger.WarnFormat("【ImportMilestones】没有上传任何里程碑模板文件！");
                return;
            }

            if (_context.MilestoneTemplates.Query.Any(m => m.Name == templateName))
            {
                var errorMessage = string.Format("系统中已经有名称为【{0}】的里程碑模板了！", templateName);
                _logger.Error(errorMessage);
                throw new InvalidOperationException(errorMessage);
            }

            var template = new MilestoneTemplate() { Name = templateName };
            var workbook = new HSSFWorkbook(xls[0].InputStream);
            var worksheet = workbook.GetSheetAt(0);
            var rowIdx = 0;
            var lastRowIdx = worksheet.LastRowNum;
            while (rowIdx <= lastRowIdx)
            {
                rowIdx++;
                var row = worksheet.GetRow(rowIdx);
                string name = null;
                double duration = 0.0d;
                try
                {
                    name = row.GetCell(0).StringCellValue;
                }
                catch (Exception e)
                {
                    _logger.WarnFormat("【ImportMilestones】导入里程碑模板\"{0}\"的第{1}行出错，其没有里程碑工期的数据，错误原因：{2}\n堆栈：{3}",
                        xls[0].FileName, rowIdx + 1, e.Message, e.StackTrace);
                    continue;
                }

                try
                {
                    duration = row.GetCell(1).NumericCellValue;
                }
                catch (Exception e)
                {
                    _logger.WarnFormat("【ImportMilestones】导入里程碑模板\"{0}\"的第{1}行出错，其没有里程碑工期的数据，错误原因：{2}\n堆栈：{3}",
                        xls[0].FileName, rowIdx + 1, e.Message, e.StackTrace);
                    continue;
                }

                var item = new MilestoneTemplateItem() { Name = name, Distance = (int)duration, DistanceUnit = (int)DistanceUnit.ByWeeks };
                template.Milestones.Add(item);
            }

            _context.MilestoneTemplates.Add(template);
            _context.SaveChanges();
        }

        public void ImportRoles(string templateName, System.Web.HttpPostedFileBase[] xls)
        {
            throw new NotImplementedException();
        }

        public void ImportTasks(string templateName, System.Web.HttpPostedFileBase[] xls)
        {
            throw new NotImplementedException();
        }

        public MilestoneTemplate[] GetMilestoneTemplates()
        {
            return _context.MilestoneTemplates.Query.ToArray();
        }

        /// <summary>
        /// 从指定的里程碑模板里创建里程碑列表
        /// </summary>
        /// <param name="templateId">指定的里程碑模板的Id</param>
        /// <returns>创建的里程碑列表</returns>
        public int CreateMilestones(int templateId)
        {
            throw new NotImplementedException();
        }
    }
}
