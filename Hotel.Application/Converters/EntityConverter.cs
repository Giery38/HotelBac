using Hotel.Core.Models.Common;
using Hotel.Core.Models.Hotel;
using Hotel.Core.Models.Users.Common;
using Hotel.Core.Models.Users.Guests;
using Hotel.Core.Models.Users.Staff;
using Hotel.Data.Models;
using Hotel.Data.Models.Hotel;
using Hotel.Data.Models.Users.Common;
using Hotel.Data.Models.Users.Guests;
using Hotel.Data.Models.Users.Staff;

namespace Hotel.Application.Converters
{
    public static class EntityConverter // передовать выше стоящие объекты вниз по ииерархии
    {
        #region ENTITY_TO_MODEL

        public static Model ToModel(this Entity entity)
        {
            switch (entity)
            {
                case HotelEntity:
                    HotelEntity hotelEntity = entity as HotelEntity;
                    return hotelEntity.ToModel();

                case RoomEntity:
                    RoomEntity roomEntity = entity as RoomEntity;
                    return roomEntity.ToModel();

                case RoomTypeEntity:
                    RoomTypeEntity roomTypeEntity = entity as RoomTypeEntity;
                    return roomTypeEntity.ToModel();

                case ServiceEntity:
                    ServiceEntity serviceEntity = entity as ServiceEntity;
                    return serviceEntity.ToModel();

                case ServiceTypeEntity:
                    ServiceTypeEntity serviceTypeEntity = entity as ServiceTypeEntity;
                    return serviceTypeEntity.ToModel();

                case RoomViewEntity:
                    RoomViewEntity roomViewEntity = entity as RoomViewEntity;
                    return roomViewEntity.ToModel();

                case UserEntity:
                    UserEntity userEntity = entity as UserEntity;
                    return userEntity.ToModel();

                case UserFeedbackEntity:
                    UserFeedbackEntity userFeedbackEntity = entity as UserFeedbackEntity;
                    return userFeedbackEntity.ToModel();

                case BookingEntity:
                    BookingEntity bookingEntity = entity as BookingEntity;
                    return bookingEntity.ToModel();

                case PositionTypeEntity:
                    PositionTypeEntity positionTypeEntity = entity as PositionTypeEntity;
                    return positionTypeEntity.ToModel();

                default:
                    return default;
            }
        }
        private static void CheckSkipModels<TEntity, TModel>(Model invoker, List<TModel> result, List<TEntity> entities, Model skipModel)
    where TEntity : Entity
    where TModel : Model
        {
            if (skipModel == null)
            {
                entities.ForEach(x => result.Add(x.ToModel(invoker) as TModel));
                return;
            }
            foreach (TEntity item in entities)
            {
                if (item.Id == skipModel.Id && skipModel is TModel)
                {
                    result.Add(skipModel as TModel);
                }
                else
                {
                    result.Add(item.ToModel(invoker) as TModel);
                }
            }
        }

        private static void CheckSkipModel<TEntity, TModel>(TModel model, TEntity entity, Model skipModel)
             where TEntity : Entity
             where TModel : Model
        {            
            if (skipModel != null && entity.Id == skipModel.Id && skipModel is TModel)
            {
                model = skipModel as TModel;
            }
            else
            {
                model = entity.ToModel(model) as TModel;
            }
        }
        private static Model ToModel(this Entity entity, Model skipModel)
        {
            switch (entity)
            {
                case HotelEntity:
                    HotelEntity hotelEntity = entity as HotelEntity;
                    return hotelEntity.ToModel(skipModel);

                case RoomEntity:
                    RoomEntity roomEntity = entity as RoomEntity;
                    return roomEntity.ToModel(skipModel);

                case RoomTypeEntity:
                    RoomTypeEntity roomTypeEntity = entity as RoomTypeEntity;
                    return roomTypeEntity.ToModel(skipModel);

                case ServiceEntity:
                    ServiceEntity serviceEntity = entity as ServiceEntity;
                    return serviceEntity.ToModel(skipModel);

                case ServiceTypeEntity:
                    ServiceTypeEntity serviceTypeEntity = entity as ServiceTypeEntity;
                    return serviceTypeEntity.ToModel(skipModel);

                case RoomViewEntity:
                    RoomViewEntity roomViewEntity = entity as RoomViewEntity;
                    return roomViewEntity.ToModel(skipModel);

                case UserEntity:
                    UserEntity userEntity = entity as UserEntity;
                    return userEntity.ToModel(skipModel);

                case UserFeedbackEntity:
                    UserFeedbackEntity userFeedbackEntity = entity as UserFeedbackEntity;
                    return userFeedbackEntity.ToModel(skipModel);

                case BookingEntity:
                    BookingEntity bookingEntity = entity as BookingEntity;
                    return bookingEntity.ToModel(skipModel);

                case PositionTypeEntity:
                    PositionTypeEntity positionTypeEntity = entity as PositionTypeEntity;
                    return positionTypeEntity.ToModel(skipModel);

                default:
                    return default;
            }
        }

        #region HOTEL

        public static HotelModel ToModel(this HotelEntity entity)
        {
            HotelModel result = new HotelModel(entity.Id, entity.Name, entity.Location, entity.Rating,
                entity.Stars, new List<RoomModel>(),
                new List<ServiceModel>());
            CheckSkipModels(result, result.Rooms, entity.Rooms, null);
            return result;
        }
        private static HotelModel ToModel(this HotelEntity entity, Model skipModel)
        {
            HotelModel result = new HotelModel(entity.Id, entity.Name, entity.Location, entity.Rating,
                entity.Stars, new List<RoomModel>(),
                new List<ServiceModel>());
            CheckSkipModels(result, result.Rooms, entity.Rooms, skipModel);
            return result;
        }
        public static RoomModel ToModel(this RoomEntity entity)
        {
            return new RoomModel(entity.Id, entity.Number, entity.Price,
                entity.Area, entity.Rating, entity.View.ToModel(), entity.RoomType.ToModel(),
                entity.Capacity, entity.Hotel.ToModel(),
                entity.Bookings.ConvertAll(i => i.ToModel()));
        }
        private static RoomModel ToModel(this RoomEntity entity, Model skipModel)
        {
            RoomModel result = new RoomModel(entity.Id, entity.Number, entity.Price,
                entity.Area, entity.Rating, null, null,
                entity.Capacity, null,
                new List<BookingModel>());
            CheckSkipModel(result, entity, skipModel);
            return result;
        }

        public static RoomTypeModel ToModel(this RoomTypeEntity entity)
        {
            return new RoomTypeModel(entity.Id, entity.Name, entity.Rooms.ConvertAll(i => i.ToModel()));
        }

        public static ServiceModel ToModel(this ServiceEntity entity)
        {
            return new ServiceModel(entity.Id, entity.Name, entity.Price,
                entity.ServiceType.ToModel(), entity.Hotels.ConvertAll(i => i.ToModel()), entity.Bookings.ConvertAll(i => i.ToModel()));
        }

        public static ServiceTypeModel ToModel(this ServiceTypeEntity entity)
        {
            return new ServiceTypeModel(entity.Id, entity.Name, entity.Services.ConvertAll(i => i.ToModel()));
        }

        public static RoomViewModel ToModel(this RoomViewEntity entity)
        {
            return new RoomViewModel(entity.Id, entity.Name, entity.Rooms.ConvertAll(i => i.ToModel()));
        }

        #endregion HOTEL

        #region USER

        public static UserModel ToModel(this UserEntity entity)
        {
            switch (entity)
            {
                case GuestEntity:
                    GuestEntity guestEntity = entity as GuestEntity;
                    return entity.ToModel();

                case StaffEntity:
                    StaffEntity staffEntity = entity as StaffEntity;
                    return staffEntity.ToModel();

                default:
                    return default;
            }
        }
        private static UserModel ToModel(this UserEntity entity, Model skipModel)
        {
            switch (entity)
            {
                case GuestEntity:
                    GuestEntity guestEntity = entity as GuestEntity;
                    return entity.ToModel(skipModel);

                case StaffEntity:
                    StaffEntity staffEntity = entity as StaffEntity;
                    return staffEntity.ToModel(skipModel);

                default:
                    return default;
            }
        }
        public static UserFeedbackModel ToModel(this UserFeedbackEntity entity)
        {
            return new UserFeedbackModel(entity.Id, entity.User.ToModel(), (UserFeedbackTypes)Enum.Parse(typeof(UserFeedbackTypes), entity.UserFeedbackType));
        }

        public static GenderModel ToModel(this GenderEntity entity)
        {
            return new GenderModel(entity.Id, (Genders)Enum.Parse(typeof(Genders), entity.Name), entity.Users.ConvertAll(i => i.ToModel()));
        }

        public static GuestModel ToModel(this GuestEntity entity)
        {
            return new GuestModel(entity.Id, entity.Name, DateOnly.Parse(entity.BirthDate), entity.Gender.ToModel(),
                entity.Rating, entity.Feedbacks.ConvertAll(i => i.ToModel()), entity.Bookings.ConvertAll(i => i.ToModel()));
        }

        public static BookingModel ToModel(this BookingEntity entity)
        {
            return new BookingModel(entity.Id, DateTime.Parse(entity.CheckIn), DateTime.Parse(entity.CheckOut),
                entity.Cost, entity.Rooms.ConvertAll(i => i.ToModel()), entity.Guests.ConvertAll(i => i.ToModel()), entity.Services.ConvertAll(i => i.ToModel()));
        }

        public static StaffModel ToModel(this StaffEntity entity)
        {
            return new StaffModel(entity.Id, entity.Name, DateOnly.Parse(entity.BirthDate), entity.Gender.ToModel(), entity.Rating, entity.Feedbacks.ConvertAll(i => i.ToModel()), entity.PositionType.ToModel());
        }

        public static PositionTypeModel ToModel(this PositionTypeEntity entity)
        {
            return new PositionTypeModel(entity.Id, entity.Name, entity.Staff.ConvertAll(i => i.ToModel()));
        }

        #endregion USER

        #endregion ENTITY_TO_MODEL

        #region MODEL_TO_ENTITY

        public static Entity ToEntity(this Model model)
        {
            switch (model)
            {
                case HotelModel:
                    HotelModel hotelModel = model as HotelModel;
                    return hotelModel.ToEntity();

                case RoomModel:
                    RoomModel roomEntity = model as RoomModel;
                    return roomEntity.ToEntity();

                case RoomTypeModel:
                    RoomTypeModel roomTypeModel = model as RoomTypeModel;
                    return roomTypeModel.ToEntity();

                case ServiceModel:
                    ServiceModel serviceModel = model as ServiceModel;
                    return serviceModel.ToEntity();

                case ServiceTypeModel:
                    ServiceTypeModel serviceTypeModel = model as ServiceTypeModel;
                    return serviceTypeModel.ToEntity();

                case RoomViewModel:
                    RoomViewModel roomViewModel = model as RoomViewModel;
                    return roomViewModel.ToEntity();

                case UserModel:
                    UserModel userModel = model as UserModel;
                    return userModel.ToEntity();

                case GenderModel:
                    GenderModel genderModel = model as GenderModel;
                    return genderModel.ToEntity();

                case UserFeedbackModel:
                    UserFeedbackModel userFeedbackModel = model as UserFeedbackModel;
                    return userFeedbackModel.ToEntity();

                case BookingModel:
                    BookingModel bookingModel = model as BookingModel;
                    return bookingModel.ToEntity();

                case PositionTypeModel:
                    PositionTypeModel positionTypeModel = model as PositionTypeModel;
                    return positionTypeModel.ToEntity();

                default:
                    return default;
            }
        }

        private static void CheckSkipEntities<TEntity, TModel>(Entity invoker, List<TEntity> result, List<TModel> models, Entity skipEntity)
            where TEntity : Entity
            where TModel : Model
        {
            if (skipEntity == null)
            {
                models.ForEach(x => result.Add(x.ToEntity(invoker) as TEntity));
                return;
            }
            foreach (TModel item in models)
            {
                if (skipEntity != null && item.Id == skipEntity.Id && skipEntity is TEntity)
                {
                    result.Add(skipEntity as TEntity);
                }
                else
                {
                    result.Add(item.ToEntity(invoker) as TEntity);
                }
            }
        }

        private static void CheckSkipEntity<TEntity, TModel>(TEntity entity, TModel model, Entity skipEntity)
             where TEntity : Entity
             where TModel : Model
        {
            if (model.Id == skipEntity.Id && skipEntity is TEntity)
            {
                entity = skipEntity as TEntity;
            }
            else
            {
                entity = model.ToEntity(entity) as TEntity;
            }
        }

        private static Entity ToEntity(this Model model, Entity skipEntity)
        {
            switch (model)
            {
                case HotelModel:
                    HotelModel hotelModel = model as HotelModel;
                    return hotelModel.ToEntity(skipEntity);

                case RoomModel:
                    RoomModel roomEntity = model as RoomModel;
                    return roomEntity.ToEntity(skipEntity);

                case RoomTypeModel:
                    RoomTypeModel roomTypeModel = model as RoomTypeModel;
                    return roomTypeModel.ToEntity(skipEntity);

                case ServiceModel:
                    ServiceModel serviceModel = model as ServiceModel;
                    return serviceModel.ToEntity(skipEntity);

                case ServiceTypeModel:
                    ServiceTypeModel serviceTypeModel = model as ServiceTypeModel;
                    return serviceTypeModel.ToEntity(skipEntity);

                case RoomViewModel:
                    RoomViewModel roomViewModel = model as RoomViewModel;
                    return roomViewModel.ToEntity(skipEntity);

                case UserModel:
                    UserModel userModel = model as UserModel;
                    return userModel.ToEntity(skipEntity);

                case GenderModel:
                    GenderModel genderModel = model as GenderModel;
                    return genderModel.ToEntity(skipEntity);

                case UserFeedbackModel:
                    UserFeedbackModel userFeedbackModel = model as UserFeedbackModel;
                    return userFeedbackModel.ToEntity(skipEntity);

                case BookingModel:
                    BookingModel bookingModel = model as BookingModel;
                    return bookingModel.ToEntity(skipEntity);

                case PositionTypeModel:
                    PositionTypeModel positionTypeModel = model as PositionTypeModel;
                    return positionTypeModel.ToEntity(skipEntity);

                default:
                    return default;
            }
        }

        #region HOTEL

        public static HotelEntity ToEntity(this HotelModel model)
        {
            HotelEntity result = new HotelEntity()
            {
                Id = model.Id,
                Location = model.Location,
                Name = model.Name,
                Rating = model.Rating,
                Rooms = new List<RoomEntity>(),
                Services = new List<ServiceEntity>(),
                Stars = model.Stars
            };
            CheckSkipEntities(result, result.Rooms, model.Rooms, null);
            CheckSkipEntities(result, result.Services, model.Services, null);
            return result;
        }

        private static HotelEntity ToEntity(this HotelModel model, Entity skipEntity)
        {
            HotelEntity result = new HotelEntity()
            {
                Id = model.Id,
                Location = model.Location,
                Name = model.Name,
                Rating = model.Rating,
                Rooms = new List<RoomEntity>(),
                Services = new List<ServiceEntity>(),
                Stars = model.Stars
            };
            CheckSkipEntities(result, result.Rooms, model.Rooms, skipEntity);
            CheckSkipEntities(result, result.Services, model.Services, skipEntity);
            return result;
        }

        public static RoomEntity ToEntity(this RoomModel model)
        {
            RoomEntity result = new RoomEntity()
            {
                Id = model.Id,
                Area = model.Area,
                Rating = model.Rating,
                View = null,
                ViewId = model.View.Id,
                Bookings = model.Bookings.ConvertAll(i => i.ToEntity()),
                Number = model.Number,
                Capacity = model.Capacity,
                Price = model.Price,
                Hotel = model.Hotel.ToEntity(),
                HotelId = model.Hotel.Id,
                RoomType = model.RoomType.ToEntity(),
                RoomTypeId = model.RoomType.Id
            };
            CheckSkipEntity(result.View, model.View, null);
            return result;
        }

        private static RoomEntity ToEntity(this RoomModel model, Entity skipEntity)
        {
            RoomEntity result = new RoomEntity()
            {
                Id = model.Id,
                Area = model.Area,
                Rating = model.Rating,
                View = null,
                ViewId = model.View.Id,
                Bookings = model.Bookings.ConvertAll(i => i.ToEntity()),
                Number = model.Number,
                Capacity = model.Capacity,
                Price = model.Price,
                Hotel = model.Hotel.ToEntity(),
                HotelId = model.Hotel.Id,
                RoomType = model.RoomType.ToEntity(),
                RoomTypeId = model.RoomType.Id
            };
            CheckSkipEntity(result.View, model.View, skipEntity);

            return result;
        }

        public static RoomTypeEntity ToEntity(this RoomTypeModel model)
        {
            return new RoomTypeEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Rooms = model.Rooms.ConvertAll(i => i.ToEntity())
            };
        }

        public static ServiceEntity ToEntity(this ServiceModel model)
        {
            return new ServiceEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                ServiceType = model.ServiceType.ToEntity(),
                ServiceTypeId = model.ServiceType.Id,
                Hotels = model.Hotels.ConvertAll(i => i.ToEntity())
            };
        }

        public static ServiceTypeEntity ToEntity(this ServiceTypeModel model)
        {
            return new ServiceTypeEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Services = model.Services.ConvertAll(i => i.ToEntity())
            };
        }

        public static RoomViewEntity ToEntity(this RoomViewModel model)
        {
            return new RoomViewEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Rooms = model.Rooms.ConvertAll(i => i.ToEntity())
            };
        }

        #endregion HOTEL

        #region USER

        public static UserEntity ToEntity(this UserModel model)
        {
            switch (model)
            {
                case GuestModel:
                    GuestModel guestModel = model as GuestModel;
                    return guestModel.ToEntity();

                case StaffModel:
                    StaffModel staffModel = model as StaffModel;
                    return staffModel.ToEntity();

                default:
                    return default;
            }
        }

        private static UserEntity ToEntity(this UserModel model, Entity skipEntity)
        {
            switch (model)
            {
                case GuestModel:
                    GuestModel guestModel = model as GuestModel;
                    return guestModel.ToEntity(skipEntity);

                case StaffModel:
                    StaffModel staffModel = model as StaffModel;
                    return staffModel.ToEntity(skipEntity);

                default:
                    return default;
            }
        }

        public static GenderEntity ToEntity(this GenderModel model)
        {
            return new GenderEntity()
            {
                Id = model.Id,
                Name = model.Gender.ToString(),
                Users = model.Users.ConvertAll(i => i.ToEntity())
            };
        }

        public static UserFeedbackEntity ToEntity(this UserFeedbackModel model)
        {
            return new UserFeedbackEntity()
            {
                Id = model.Id,
                UserFeedbackType = model.UserFeedbackType.ToString(),
                User = model.User.ToEntity(),
                UserId = model.User.Id
            };
        }

        public static GuestEntity ToEntity(this GuestModel model)
        {
            return new GuestEntity()
            {
                Id = model.Id,
                Name = model.Name,
                BirthDate = model.BirthDate.ToString(),
                Gender = model.Gender.ToEntity(),
                Bookings = model.Bookings.ConvertAll(i => i.ToEntity())
            };
        }

        public static BookingEntity ToEntity(this BookingModel model)
        {
            return new BookingEntity()
            {
                CheckIn = model.CheckIn.ToString(),
                CheckOut = model.CheckOut.ToString(),
                Id = model.Id,
                Cost = model.Cost,
                Guests = model.Guests.ConvertAll(i => i.ToEntity()),
                Rooms = model.Rooms.ConvertAll(i => i.ToEntity())
            };
        }

        public static StaffEntity ToEntity(this StaffModel model)
        {
            return new StaffEntity()
            {
                Id = model.Id,
                BirthDate = model.BirthDate.ToString(),
                Name = model.Name,
                Gender = model.Gender.ToEntity(),
                GenderId = model.Gender.Id,
                Rating = model.Rating,
                PositionType = model.PositionType.ToEntity(),
                PositionId = model.PositionType.Id,
                Feedbacks = model.Feedbacks.ConvertAll(i => i.ToEntity())
            };
        }

        public static PositionTypeEntity ToEntity(this PositionTypeModel model)
        {
            return new PositionTypeEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Staff = model.Staff.ConvertAll(i => i.ToEntity())
            };
        }

        #endregion USER

        #endregion MODEL_TO_ENTITY
    }
}