using ShopTARgv23.Core.Domain;
using ShopTARgv23.Core.Dto;
using ShopTARgv23.Core.ServiceInterface;

namespace ShopTARgv23.KindergartenTest
{
    public class KindergartenTest : TestBase
    {
        [Fact]
        public async void ShouldNotAddEmptyRealEstate_WhenReturnResult()
        {
            // Arrange
            KindergartenDto dto = new();

            dto.GroupName = "Geb";
            dto.ChildrenCount = 123;
            dto.KindergartenName = "Kid";
            dto.Teacher = "Bob";
            dto.CreatedAt = DateTime.Now;
            dto.UpdatedAt = DateTime.Now;

            // Act
            var result = await Svc<IKindergartenServices>().Create(dto);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdRealestate_WhenReturnsNotEqual()
        {
            // Aramge
            Guid WrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("82c6af77-2c7d-4eae-8e1e-29269c3c9862");

            // Act 
            await Svc<IKindergartenServices>().DetailsAsync(guid);

            Assert.NotEqual(WrongGuid, guid);
        }

        [Fact]
        public async Task Should_GetByIdRealEstate_WhenReturnEqual()
        {
            // Aramge
            Guid CorrectGuid = Guid.Parse("82c6af77-2c7d-4eae-8e1e-29269c3c9862");
            Guid guid = Guid.Parse("82c6af77-2c7d-4eae-8e1e-29269c3c9862");

            // Act 
            await Svc<IKindergartenServices>().DetailsAsync(guid);

            // Assert
            Assert.Equal(CorrectGuid, guid);
        }

        [Fact]
        public async Task Should_DeleteByIdRealEstate_WhereDeleteRealEstate()
        {
            KindergartenDto kindergarten = MockKindergartenData();

            var Kindergarten1 = await Svc<IKindergartenServices>().Create(kindergarten);
            var Kindergarten2 = await Svc<IKindergartenServices>().Create(kindergarten);

            var result = await Svc<IKindergartenServices>().Delete((Guid)Kindergarten1.Id);

            Assert.NotEqual(result.Id, Kindergarten2.Id);
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdRealEstate_WhereDeleteRealEstate()
        {
            KindergartenDto kindergarten = MockKindergartenData();

            var addRealEstate = await Svc<IKindergartenServices>().Create(kindergarten);

            var result = await Svc<IKindergartenServices>().Delete((Guid)addRealEstate.Id);

            Assert.False(string.IsNullOrEmpty(result.GroupName));
        }

        [Fact]
        public async Task Should_UpdataRealEstate_WhenUpdateData()
        {

            var guid = Guid.Parse("82c6af77-2c7d-4eae-8e1e-29269c3c9862");
            KindergartenDto dto = MockKindergartenData();

            Kindergarten domain = new();

            domain.Id = Guid.Parse("82c6af77-2c7d-4eae-8e1e-29269c3c9862");
            domain.GroupName = "adsg";
            domain.ChildrenCount = 1;
            domain.KindergartenName = "ashd";
            domain.Teacher = "as";
            domain.CreatedAt = DateTime.UtcNow;
            domain.UpdatedAt = DateTime.UtcNow;

            await Svc<IKindergartenServices>().Update(dto);

            Assert.Equal(domain.Id, guid);
            Assert.DoesNotMatch(domain.GroupName, dto.GroupName);
            Assert.NotEqual(domain.ChildrenCount, dto.ChildrenCount);
            Assert.DoesNotMatch(domain.KindergartenName, dto.KindergartenName);
            Assert.DoesNotMatch(domain.Teacher, dto.Teacher);

        }

        [Fact]
        public async Task Should_UpdataRealEstate_WhenUpdateDataVersion2()
        {
            KindergartenDto dto = MockKindergartenData();
            var CreateKindergarten = await Svc<IKindergartenServices>().Create(dto);

            KindergartenDto update = MockUpdateKindergartenData();

            var result = await Svc<IKindergartenServices>().Update(update);

            Assert.DoesNotMatch(CreateKindergarten.GroupName, result.GroupName);
            Assert.NotEqual(CreateKindergarten.ChildrenCount, result.ChildrenCount);
            Assert.DoesNotMatch(CreateKindergarten.KindergartenName, result.KindergartenName);
            Assert.DoesNotMatch(CreateKindergarten.Teacher, result.Teacher);

            Assert.NotEqual(CreateKindergarten.UpdatedAt, result.UpdatedAt);

        }

        [Fact]
        public async Task ShouldNot_UpdataRealEstate_WhenUpdateData()
        {
            KindergartenDto dto = MockKindergartenData();
            var CreateRealEstate = await Svc<IKindergartenServices>().Create(dto);

            KindergartenDto NullUpdate = MockNullKindergartenData();
            var result = await Svc<IKindergartenServices>().Create(NullUpdate);

            var NullId = NullUpdate.Id;

            Assert.True(dto.Id == NullId);
        }

        [Fact]
        public async Task ShouldNot_UpdataRealEstate_WhenNotUpdateData()
        {
            KindergartenDto dto = MockKindergartenData();
            var CreateRealEstate = await Svc<IKindergartenServices>().Create(dto);

            KindergartenDto update = MockNullKindergartenData();
            var result = await Svc<IKindergartenServices>().Create(update);

            Assert.NotEqual(result.Id, dto.Id);
        }

        [Fact]
        public async Task Should_ReturnNull_WhenRealEstateDoesNotExist()
        {
            Guid NonExistingId = Guid.NewGuid();

            var result = await Svc<IKindergartenServices>().DetailsAsync(NonExistingId);

            Assert.Null(result);
        }

        public async Task Should_CreateDataEntries()
        {
            KindergartenDto mock = MockKindergartenData();
            var CreateRealEstate = await Svc<IKindergartenServices>().Create(mock);

            Assert.NotNull(CreateRealEstate.Id);

            Assert.NotNull(CreateRealEstate.CreatedAt);
            Assert.NotNull(CreateRealEstate.UpdatedAt);
        }

        private KindergartenDto MockKindergartenData()
        {
            KindergartenDto kindergarten = new()
            {
                GroupName = "Geb",
                ChildrenCount = 123,
                KindergartenName = "Kid",
                Teacher = "Bob",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            return kindergarten;
        }

        private KindergartenDto MockUpdateKindergartenData()
        {
            KindergartenDto kindergarten = new()
            {
                GroupName = "Geb",
                ChildrenCount = 123,
                KindergartenName = "Kid",
                Teacher = "Bob",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            return kindergarten;

        }

        private KindergartenDto MockNullKindergartenData()
        {
            KindergartenDto NullDto = new()
            {
                Id = null,
                GroupName = "Geb",
                ChildrenCount = 123,
                KindergartenName = "Kid",
                Teacher = "Bob",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            return NullDto;

        }
    }
}