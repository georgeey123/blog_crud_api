using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using blog_crud1.Data;
using blog_crud1.Models;

namespace blog_crud1.Manager
{
    public class PostManager
    {
        private readonly BlogDbContext _context;

        public PostManager(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePost(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();

            return post.PostId;
        }

        public async Task DeletePost(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.PostId == id);

            if (post == null)
                throw new Exception("Invalid Id");

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task<Post?> GetPostById(int id)
        {
            var post = await _context.Posts.Include(c => c.Comments).FirstOrDefaultAsync(x => x.PostId == id);

            if (post == null)
                throw new Exception("Invalid Id");
            return post;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts;
        }

        public async Task UpdatePost(int id, Post updatedPost)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.PostId == id);

            if (post == null)
                throw new Exception("Invalid Id");

            post.Content = updatedPost.Content;
            await _context.SaveChangesAsync();
        }
    }

}