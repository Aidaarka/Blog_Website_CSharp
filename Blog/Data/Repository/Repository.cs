using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data.Repository
{
    public class Repository : IRepository
    {
        private AppDbContext _ctx;

        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddPost(Post post)
        {
            _ctx.Posts.Add(post);
        }

        public List<Post> GetAllPosts()
        {
            return _ctx.Posts.ToList();
        }
        public List<Post> GetAllPosts(string category)
        {
            return _ctx.Posts
                .Where(post => post.Category.ToLower().Equals(category.ToLower()))
                .ToList();
        }

        public Post GetPost(int id)
        {
            return _ctx.Posts.FirstOrDefault(p => p.Id == id);
        }

        public void UpdatePost(Post post)
        {
            _ctx.Posts.Update(post);
        }

        public void RemovePost(int id)
        {
            _ctx.Posts.Remove(GetPost(id));
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _ctx.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
