using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TaskAPI.Models;
using TaskAPI.Models.BLL;
using TaskAPI.Models.BOL;
using TaskAPI.Models.DAL;

namespace TaskAPI.Controllers
{
    //[EnableCorsAttribute("http://localhost:63129", "*", "*")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MembersController : ApiController
    {
        private UnitOfWork  db  = new UnitOfWork();


        [HttpGet]
        [Route("api/getAllMembers")]
        public IQueryable<MemberProject> GetMembers()
        {
            return db.MemberProject.GetAll();
        }

        // GET: api/Members
        [HttpGet]
        [Route("api/getMembersByProject/{id}")]
        public IQueryable<MemberProject> GetProjectsMembers(int id)
        {
            return db.MemberProject.GetProjectMembers(id);
        }

        // GET: api/Members/5
        [HttpGet]
        [Route("api/member/{id}")]
        public IHttpActionResult GetMember(int id)
        {
            var memberProject = db.MemberProject.GetMemberProjectById(id);
            if (memberProject == null)
            {
                return NotFound();
            }

            return Ok(memberProject);
        }

        // POST: api/Members/5
        [HttpPost]
        [Route("api/member/update")]
        public IHttpActionResult UpdateMember(Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Member.Update(member);
            db.Save();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Members
        [HttpPost]
        [Route("api/member/create")]
        public IHttpActionResult CreateMember(Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Member.Create(member);
            db.Save();

            return Ok(member);
            //return CreatedAtRoute("DefaultApi", new { id = member.Id }, member);
        }

        /// <summary>  
        /// This method take employee object and find index of employee from list  
        /// and Remove record from particular index and add record in list.  
        /// </summary>  
        /// <param name="emp">epmployee record with updated data. </param>  
        /// <returns>return true after updation.</returns>
        // POST: api/Members/5
        [HttpDelete]
        [Route("api/member/delete/{id}")]
        public IHttpActionResult DeleteMember(int id)
        {
            Member member = db.Member.Find((m => m.Id.Equals(id))).FirstOrDefault();
            if (member == null)
            {
                return NotFound();
            }

            db.Member.Delete(member);
            db.Save();

            return Ok(member);
        }

    }
}