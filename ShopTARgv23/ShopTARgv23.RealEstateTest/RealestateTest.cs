using Azure.Core;
using ShopTARgv23.Core.Dto;
using ShopTARgv23.Core.ServiceInterface;
using System.Reflection.Metadata.Ecma335;


namespace ShopTARgv23.RealEstateTest
{
    public class RealestateTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyRealEstate_WhenReturnResult()
        {
            //Arrange
            RealEstateDto dto = new();

            dto.Location = "asd";
            dto.Size = 123;
            dto.RoomNumber = 123;
            dto.BuildingType = "asd";
            dto.CreatedAt = DateTime.Now;
            dto.ModifiedAt = DateTime.Now;

            //Act
            var result = await Svc<IRealEstateServices>().Create(dto);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdRealestate_WhenReturnsNotEqual()
        {
            //Arrange
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("1f9e4cce-85a7-4eb7-8379-b12a150fee10");

            //Act
            await Svc<IRealEstateServices>().GetAsync(guid);

            //Assert
            Assert.NotEqual(wrongGuid, guid);
        }

        [Fact]
        public async Task Should_GetByIdRealEstate_WhenReturnsEqual()
        {
            Guid correctGuid = Guid.Parse("1f9e4cce-85a7-4eb7-8379-b12a150fee10");
            Guid guid = Guid.Parse("1f9e4cce-85a7-4eb7-8379-b12a150fee10");

            //Act
            await Svc<IRealEstateServices>().GetAsync(guid);

            //Assert
            Assert.Equal(correctGuid, guid);
        }
        [Fact]
        public async Task Should_DeleteByIdRealEstate_WhenDeleteRealEstate()
        {
            //Arrange
            RealEstateDto realEstate = MockRealEstateData();
            var addRealEstate = await Svc<IRealEstateServices>().Create(realEstate);

            //Act

            var result = await Svc<IRealEstateServices>().Delete((Guid)addRealEstate.Id);
            Assert.Equal(result, addRealEstate);


        }
        [Fact]

        public async Task ShouldNot_DeleteByIdRealEstate_WhenDidNotDeleteRealEstate()
        {
            //Arrange
            RealEstateDto realEstate = MockRealEstateData();
            var addRealEstate = await Svc<IRealEstateServices>().Create(realEstate);

            //Act
            var result = await Svc<IRealEstateServices>().Delete((Guid)addRealEstate.Id);
            Assert.NotEqual(result, addRealEstate);
        }


        private RealEstateDto MockRealEstateData()
        {
            return new RealEstateDto
            {
                Location = "asd",
                Size = 123,
                RoomNumber = 123,
                BuildingType = "asd",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

        }

        
        
    }
}




