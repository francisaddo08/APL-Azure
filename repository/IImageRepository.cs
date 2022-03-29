using APL_Technical_Test.data.entities;

namespace APL_Technical_Test.repository
{
    public interface IImageRepository : IRepository<ImageInformation>
    {
        int save();
    }
}
