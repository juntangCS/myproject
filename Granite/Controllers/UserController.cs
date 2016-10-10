using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData.Extensions;
using System.Web.OData.Query;
using AutoMapper;
using Granite.Models.User;
using Granite.Service.User;
using Saas.Business.Entities;
using Saas.Infrastructure.Utility.Searchs;

namespace Granite.Controllers
{
    /// <summary>
    /// user controller.
    /// </summary>
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly UserFacadeService _userFacadeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userFacadeService">The user facade service.</param>
        public UserController(UserFacadeService userFacadeService)
        {
            _userFacadeService = userFacadeService;
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [Route("{id:int}", Name = "GetUser")]
        [ResponseType(typeof(UserViewModel))]
        public IHttpActionResult Get(int id)
        {
            var user = _userFacadeService.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            var userViewModel = Mapper.Map<UserViewModel>(user);
            return Ok(userViewModel);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        [Route("")]
        [ResponseType(typeof(PagedResult<UserQueryModel>))]
        public IHttpActionResult GetAll(ODataQueryOptions<User> options)
        {
            var users = _userFacadeService.GetAll();
            options.Validate(new ODataValidationSettings());
            var filteruser = (IQueryable<User>)options.ApplyTo(users);
            var userQueryModel = Mapper.Map<IEnumerable<UserQueryModel>>(filteruser);
            var pageResult = new PagedResult<UserQueryModel>(userQueryModel,Request.ODataProperties().TotalCount);
            return Ok(pageResult);
        }

        /// <summary>
        /// Posts the specified user create model.
        /// </summary>
        /// <param name="userCreateModel">The user create model.</param>
        [Route("")]
        [ResponseType(typeof(PagedResult<UserViewModel>))]
        public IHttpActionResult Post(UserCreateModel userCreateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = Mapper.Map<User>(userCreateModel);
            _userFacadeService.Add(user);
            var userViewModel = Mapper.Map<UserViewModel>(user);
            return CreatedAtRoute("GetUser", new {id = userViewModel.Id}, userViewModel);
        }

        /// <summary>
        /// Puts the specified user update model.
        /// </summary>
        /// <param name="userUpdateModel">The user update model.</param>
        /// <param name="id">The identifier.</param>
        [Route("{id:int}")]
        public IHttpActionResult Put(UserUpdateModel userUpdateModel, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _userFacadeService.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            Mapper.Map(userUpdateModel, user);
            _userFacadeService.Update(user);
            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var user = _userFacadeService.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            _userFacadeService.Delete(user);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}