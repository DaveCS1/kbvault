﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KBVault.Dal
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    //using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class KbVaultEntities : DbContext
    {
        public KbVaultEntities()
            : base("name=KbVaultEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<KbUser> KbUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Activity> Activities { get; set; }
    
        public virtual int AssignTagsToArticle(Nullable<long> articleId, string tags)
        {
            var articleIdParameter = articleId.HasValue ?
                new ObjectParameter("ArticleId", articleId) :
                new ObjectParameter("ArticleId", typeof(long));
    
            var tagsParameter = tags != null ?
                new ObjectParameter("Tags", tags) :
                new ObjectParameter("Tags", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AssignTagsToArticle", articleIdParameter, tagsParameter);
        }
    
        public virtual int RemoveTagFromArticles(Nullable<long> tagId)
        {
            var tagIdParameter = tagId.HasValue ?
                new ObjectParameter("TagId", tagId) :
                new ObjectParameter("TagId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RemoveTagFromArticles", tagIdParameter);
        }
    
        public virtual ObjectResult<TopTagItem> GetTopTags()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TopTagItem>("GetTopTags");
        }
    
        public virtual ObjectResult<SimilarArticle> GetSimilarArticles(Nullable<int> articleId)
        {
            var articleIdParameter = articleId.HasValue ?
                new ObjectParameter("ArticleId", articleId) :
                new ObjectParameter("ArticleId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SimilarArticle>("GetSimilarArticles", articleIdParameter);
        }
    }
}
