using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
                //TODO:guncelle
                _userDal.Add(user);
                return new SuccessResult(Messages.CustomerAddes);
                        
        }
        public IResult Delete(User user)
        {
                //TODO:guncelle
                _userDal.Delete(user);
                return new SuccessResult(Messages.CustomerDeleted);
          
        }
        public IResult Update(User user)
        {
                //TODO:guncelle
                _userDal.Update(user);
                return new SuccessResult(Messages.CustomerUpdates);
                      
        }
        public IDataResult<List<User>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<User>>(_userDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<User>>(ex.Message);
            }
        }
        public IDataResult<User> GetById(int userID)
        {
                return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userID));
            
        }
    }
}
