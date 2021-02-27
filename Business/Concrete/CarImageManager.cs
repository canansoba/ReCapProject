using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, string extension)
        {
            IResult result = BusinessRules.Run(
                CheckCarImageCount(carImage.ProductId)
                );

            if (result != null)
            {
                return result;
            }

            var addedCarImage = CreatedFile(carImage, extension).Data;
            _carImageDal.Add(addedCarImage);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CarImageDelete(carImage));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);

        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<List<CarImage>> GetCarImage(int productId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.ProductId == productId));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage)
        {
            var carImageUpdate = UpdatedFile(carImage).Data;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckCarImageCount(int carId)
        {
            var result = _carImageDal.GetAll(c => c.ProductId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.MaxCarImage);
            }

            return new SuccessResult();
        }

        private IDataResult<CarImage> CreatedFile(CarImage carImage, string extension)
        {

            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");

            var creatingUniqueFilename = Guid.NewGuid().ToString("N")
                + "_" + DateTime.Now.Month + "_"
                + DateTime.Now.Day + "_"
                + DateTime.Now.Year + extension;

            string source = Path.Combine(carImage.ImagePath);

            string result = $@"{path}\{creatingUniqueFilename}";

            try
            {

                File.Move(source, path + @"\" + creatingUniqueFilename);
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<CarImage>(exception.Message);
            }

            return new SuccessDataResult<CarImage>(new CarImage { Id = carImage.Id, ProductId = carImage.ProductId, ImagePath = result, Date = DateTime.Now }, Messages.ImagesAdded);
        }
        private IResult CarImageDelete(CarImage carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        private IDataResult<CarImage> UpdatedFile(CarImage carImage)
        {
            var creatingUniqueFilename = Guid.NewGuid().ToString("N") + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + ".jpeg";

            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");

            string result = $"{path}\\{creatingUniqueFilename}";

            File.Copy(carImage.ImagePath, path + "\\" + creatingUniqueFilename);

            File.Delete(carImage.ImagePath);

            return new SuccessDataResult<CarImage>(new CarImage { Id = carImage.Id, ProductId = carImage.ProductId, ImagePath = result, Date = DateTime.Now });
        }
        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images\default.jpg");
            var result = _carImageDal.GetAll(c => c.ProductId == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { ProductId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.ProductId == id);
        }

    }
}
