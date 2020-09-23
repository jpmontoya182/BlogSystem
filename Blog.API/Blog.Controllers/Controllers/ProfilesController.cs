using System;
using System.Collections.Generic;
using System.Text;
using Blog.Models;
using Blog.Models.DataBase;
using Blog.Models.Request;
using Blog.Repos;
using Blog.Repos.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Blog.Controllers.Controllers
{
    [Route("api/Profiles")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IOptions<SetUpModel> _setup;
        private readonly UnitofWork _unitOfWork;

        public ProfilesController(IOptions<SetUpModel> setup, IUnitOfWork uow)
        {
            _setup = setup;
            _unitOfWork = uow as UnitofWork;
        }

        #region Profiles

        [HttpGet]
        [Route("GetAllProfiles/")]
        [AllowAnonymous]

        public IEnumerable<Profiles> GetAllProfiles()
        {
            return _unitOfWork.ProfilesRepository.GetAllProfiles();
        }

        [HttpGet]
        [Route("GetProfileById/{ProfileId}")]
        [AllowAnonymous]
        public Profiles GetProfileById(string ProfileId)
        {
            Profiles result = new Profiles();
            try
            {
                int id;
                bool success = Int32.TryParse(ProfileId, out id);
                result = _unitOfWork.ProfilesRepository.GetProfileById(id);
            }
            catch (Exception)
            {
                throw;
            }
            return result;

        }

        [HttpPost]
        [Route("InsertPost/")]
        [AllowAnonymous]
        public void InsertProfile(InsertNewProfile entity)
        {
            try
            {
                _unitOfWork.ProfilesRepository.InsertProfile(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("UpdateProfile/")]
        [AllowAnonymous]
        public void UpdateProfile(UpdateProfile entity)
        {
            try
            {
                _unitOfWork.ProfilesRepository.UpdateProfile(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpDelete]
        [Route("DeleteProfile/{ProfileId}")]
        [AllowAnonymous]
        public void DeleteProfile(string ProfileId)
        {
            try
            {
                int id;
                bool success = Int32.TryParse(ProfileId, out id);
                if (success)
                {
                    _unitOfWork.ProfilesRepository.DeleteProfile(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


    }
}
