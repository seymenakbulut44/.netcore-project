using BuisnessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDal _socialmediaDal;

        public SocialMediaManager(ISocialMediaDal socialmediaDal)
        {
            _socialmediaDal = socialmediaDal;
        }

        public void Tadd(SocialMedia t)
        {
            _socialmediaDal.Insert(t);
        }

        public void TDelete(SocialMedia t)
        {
            _socialmediaDal.Delete(t);
        }

        public SocialMedia TGetByID(int id)
        {
            return _socialmediaDal.GetByID(id);
        }

        public List<SocialMedia> TGetList()
        {
            return _socialmediaDal.GetList();
        }

        public void TUpdate(SocialMedia t)
        {
            _socialmediaDal.Update(t);
        }
    }
}
