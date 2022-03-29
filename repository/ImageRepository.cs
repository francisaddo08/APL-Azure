using APL_Technical_Test.data.models;
using APL_Technical_Test.data.entities;
using APL_Technical_Test.data;
using System;

namespace APL_Technical_Test.repository
{
    public class ImageRepository : Repository<ImageInformation>, IImageRepository
    {
        public ImageRepository(ApplicationContext context):base(context)
        {

        }
        public void Add(ImageInformation model)
        {
            db.Set<ImageInformation>().Add(model);
        }

        public ImageInformation GetById(DateTime Id)
        {
            return db.Set<ImageInformation>().Find(Id);
        }

        public int save()
        {
          return  db.SaveChanges();
        }
    }
}
