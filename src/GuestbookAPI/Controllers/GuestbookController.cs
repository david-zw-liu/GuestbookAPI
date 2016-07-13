using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GuestbookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Guestbook.Controllers
{
    [Route("api/guestbook/comment")]
    public class GuestbookController : Controller
    {
        private GuestbookContext _gbContext;
        
        public GuestbookController(GuestbookContext context)
        {
            _gbContext = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return new ObjectResult( _gbContext.Comments.AsNoTracking() );
        }

        [HttpGet("{id}", Name = "GetComment")]
        public IActionResult GetById(string id)
        {
            var commentItem = _gbContext.Comments.Where(c => c.Id == Int32.Parse(id)).AsNoTracking().FirstOrDefault();

            if (commentItem == null)
            {
                return new NotFoundResult();
            }

            return new ObjectResult(commentItem);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Comment comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }

            _gbContext.Comments.Add(comment);
            _gbContext.SaveChanges();

            return CreatedAtRoute("GetComment", new { id = comment.Id }, comment);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Comment comment)
        {
            //判斷request body是否有內容, 內容 Id 與 URL參數 是否一致
            if (comment == null || comment.Id != Int32.Parse(id))
            {
                return BadRequest();
            }

            //判斷資料庫中是否有該id的資料
            var commentItem = _gbContext.Comments.Where(c => c.Id == Int32.Parse(id)).AsNoTracking().FirstOrDefault();
            if (commentItem == null)
            {
                return new NotFoundResult();
            }

            _gbContext.Comments.Update(comment);
            _gbContext.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            //尋找該id的資料
            var commentItem = _gbContext.Comments.Where(c => c.Id == Int32.Parse(id)).FirstOrDefault();            
            if(commentItem != null)
            {
                _gbContext.Comments.Remove(commentItem);
                _gbContext.SaveChanges();
            }
        }
    }
}
