﻿using part5.core;
using part5.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part5.data.DAL
{
    public class PostDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public Post GetById(long id)
        {
            var post = context.Posts
                .Where(i => i.Id == id && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
                .FirstOrDefault();
            return post;
        }

        public Post GetByAlias(string alias)
        {
            var post = context.Posts
               .Where(i => i.Alias.Contains(alias) && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
               .FirstOrDefault();
            return post;
        }

        public IEnumerable<Post> GetList()
        {
            var post = context.Posts
               .Where(i => i.IsDeleted == false || i.IsDeleted.Equals(null))
               .ToList();
            return post;
        }

        public bool Update(Post model)
        {
            try
            {
                //Get item user with Id from database
                var item = context.Posts.Where(i => i.Id == model.Id).FirstOrDefault();

                //Set value item with value from model
                item.CategoryId = model.CategoryId;
                item.Title = model.Title;
                item.Content = model.Content;
                item.Summary = model.Summary;
                item.Resource = model.Resource;
                item.Image = model.Image;
                item.Tags = model.Tags;
                item.CreatedBy = model.CreatedBy;
                item.CreatedTime = model.CreatedTime;
                item.IsDeleted = model.IsDeleted;

                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(Post model)
        {
            try
            {
                //Initialization empty item
                var post = new Post();

                post.CategoryId = model.CategoryId;
                post.Title = model.Title;
                post.Alias = StringHelper.VNDecode(model.Title);
                post.Content = model.Content;
                post.Summary = model.Summary;
                post.Resource = model.Resource;
                post.Image = model.Image;
                post.Tags = model.Tags;
                post.CreatedBy = model.CreatedBy;
                post.CreatedTime = DateTime.Now;
                post.IsDeleted = false;
                post.PostStatus = 0;

                //Add item to entity
                context.Posts.Add(post);
                //Save to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                //Tương tự update
                var item = context.Posts.SingleOrDefault(i => i.Id == id);

                //Remove item.
                context.Posts.Remove(item);

                //Change database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
