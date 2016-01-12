using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using CodeFirstIOCDemo.Dao.Core;

namespace CodeFirstIOCDemo.BusinessLogic.Core.Models
{
    [DataContract]
    public class Comment : TableItemBase, ICommentable
    {
        public Comment()
        {
            Comments = new List<Comment>();
            CommentDate = DateTime.Now;
        }

        [DataMember]
        public int EntityId { get; set; }

        [DataMember]
        public int PreviousCommentId { get; set; }

        [DataMember]
        public string EntityType { get; set; }

        /// <summary>
        /// 评论文本
        /// </summary>
        [DataMember]
        public string Text
        {
            get;
            set;
        }

        /// <summary>
        /// 评论用户
        /// </summary>
        [DataMember]
        public string User
        {
            get;
            set;
        }

        /// <summary>
        /// 评论时间
        /// </summary>
        [DataMember]
        public DateTime CommentDate
        {
            get;
            set;
        }

        [JsonIgnore]
        public virtual ICollection<Comment> Comments { get; set; }

        /// <summary>
        /// 类型（0：评论；1：系统日志跟踪；2：销售日志跟踪）
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 被评论的实体名称
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// 更新类型（编辑，增加，删除，评论）
        /// </summary>
        [DataMember]
        public string UpdateType { get; set; }
    }
}
