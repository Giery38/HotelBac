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
    public static class EntityConverter // передавать вышестоящие объекты вниз по иерархии
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
                entity.Stars, new List<RoomModel>(), new List<ServiceModel>());
            CheckSkipModels(result, result.Rooms, entity.Rooms, null);
            CheckSkipModels(result, result.Services, entity.Services, null);
            return result;
        }
        private static HotelModel ToModel(this HotelEntity entity, Model skipModel)
        {
            HotelModel result = new HotelModel(entity.Id, entity.Name, entity.Location, entity.Rating,
                entity.Stars, new List<RoomModel>(), new List<ServiceModel>());
            CheckSkipModels(result, result.Rooms, entity.Rooms, skipModel);
            CheckSkipModels(result, result.Services, entity.Services, skipModel);
            return result;
        }
        public static RoomModel ToModel(this RoomEntity entity)
        {
            RoomModel result = new RoomModel(entity.Id, entity.Number, entity.Price,
                entity.Area, entity.Rating, null, null,
                entity.Capacity, null,
                entity.Bookings.ConvertAll(i => i.ToModel()));
            CheckSkipModel(result.Hotel, entity.Hotel, null);
            CheckSkipModel(result.View, entity.View, null);
            CheckSkipModel(result.RoomType, entity.RoomType, null);
            return result;
        }
        private static RoomModel ToModel(this RoomEntity entity, Model skipModel)
        {
            RoomModel result = new RoomModel(entity.Id, entity.Number, entity.Price,
                entity.Area, entity.Rating, null, null,
                entity.Capacity, null,
                new List<BookingModel>());
            CheckSkipModel(result.Hotel, entity.Hotel, skipModel);
            CheckSkipModel(result.View, entity.View, skipModel);
            CheckSkipModel(result.RoomType, entity.RoomType, skipModel);

            return result;
        }

        public static RoomTypeModel ToModel(this RoomTypeEntity entity)
        {
            RoomTypeModel result = new RoomTypeModel(entity.Id, entity.Name, new List<RoomModel>());
            CheckSkipModels(result, result.Rooms, entity.Rooms, null);
            return result;
        }
        private static RoomTypeModel ToModel(this RoomTypeEntity entity, Model skipModel)
        {
            RoomTypeModel result = new RoomTypeModel(entity.Id, entity.Name, new List<RoomModel>());
            CheckSkipModels(result, result.Rooms, entity.Rooms, skipModel);
            return result;
        }

        public static ServiceModel ToModel(this ServiceEntity entity)
        {
            ServiceModel result = new ServiceModel(entity.Id, entity.Name, entity.Price,
                null, new List<HotelModel>(), new List<BookingModel>());
            CheckSkipModel(result.ServiceType, entity.ServiceType, null);
            CheckSkipModels(result, result.Hotels, entity.Hotels, null);
            CheckSkipModels(result, result.Bookings, entity.Bookings, null);

            return result;
        }

        private static ServiceModel ToModel(this ServiceEntity entity, Model skipModel)
        {
            ServiceModel result = new ServiceModel(entity.Id, entity.Name, entity.Price,
                null, new List<HotelModel>(), new List<BookingModel>());
            CheckSkipModel(result.ServiceType, entity.ServiceType, skipModel);
            CheckSkipModels(result, result.Hotels, entity.Hotels, skipModel);
            CheckSkipModels(result, result.Bookings, entity.Bookings, skipModel);

            return result;
        }

        public static ServiceTypeModel ToModel(this ServiceTypeEntity entity)
        {
            ServiceTypeModel result = new ServiceTypeModel(entity.Id, entity.Name, new List<ServiceModel>());
            CheckSkipModels(result, result.Services, entity.Services, null);

            return result;
        }

        private static ServiceTypeModel ToModel(this ServiceTypeEntity entity, Model skipModel)
        {
            ServiceTypeModel result = new ServiceTypeModel(entity.Id, entity.Name, new List<ServiceModel>());
            CheckSkipModels(result, result.Services, entity.Services, skipModel);

            return result;
        }

        public static RoomViewModel ToModel(this RoomViewEntity entity)
        {
            RoomViewModel result = new RoomViewModel(entity.Id, entity.Name, entity.Rooms.ConvertAll(i => i.ToModel()));
            CheckSkipModels(result, result.Rooms, entity.Rooms, null);

            return result;
        }

        private static RoomViewModel ToModel(this RoomViewEntity entity, Model skipModel)
        {
            RoomViewModel result = new RoomViewModel(entity.Id, entity.Name, entity.Rooms.ConvertAll(i => i.ToModel()));
            CheckSkipModels(result, result.Rooms, entity.Rooms, skipModel);

            return result;
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
            UserFeedbackModel result = new UserFeedbackModel(entity.Id, null, (UserFeedbackTypes)Enum.Parse(typeof(UserFeedbackTypes), entity.UserFeedbackType));
            CheckSkipModel(result.User, entity.User, null);
            return result;
        }
        private static UserFeedbackModel ToModel(this UserFeedbackEntity entity, Model skipModel)
        {
            UserFeedbackModel result = new UserFeedbackModel(entity.Id, null, (UserFeedbackTypes)Enum.Parse(typeof(UserFeedbackTypes), entity.UserFeedbackType));
            CheckSkipModel(result.User, entity.User, skipModel;
            return result;
        }

        public static GenderModel ToModel(this GenderEntity entity)
        {
            GenderModel result = new GenderModel(entity.Id, (Genders)Enum.Parse(typeof(Genders), entity.Name), new List<UserModel>());
            CheckSkipModels(result, result.Users, entity.Users, null);
            return result;
        }
        private static GenderModel ToModel(this GenderEntity entity, Model skipModel)
        {
            GenderModel result = new GenderModel(entity.Id, (Genders)Enum.Parse(typeof(Genders), entity.Name), new List<UserModel>());
            CheckSkipModels(result, result.Users, entity.Users, skipModel);
            return result;
        }

        public static GuestModel ToModel(this GuestEntity entity)
        {
            GuestModel result = new GuestModel(entity.Id, entity.Name, DateOnly.Parse(entity.BirthDate), null,
                entity.Rating, new List<UserFeedbackModel>(), new List<BookingModel>());
            CheckSkipModel(result.Gender, entity.Gender, null);
            CheckSkipModels(result, result.Feedbacks, entity.Feedbacks, null);
            CheckSkipModels(result, result.Bookings, entity.Bookings, null);

            return result;
        }
        private static GuestModel ToModel(this GuestEntity entity, Model skipModel)
        {
            GuestModel result = new GuestModel(entity.Id, entity.Name, DateOnly.Parse(entity.BirthDate), null,
                entity.Rating, new List<UserFeedbackModel>(), new List<BookingModel>());
            CheckSkipModel(result.Gender, entity.Gender, null);
            CheckSkipModels(result, result.Feedbacks, entity.Feedbacks, null);
            CheckSkipModels(result, result.Bookings, entity.Bookings, null);

            return result;
        }

        public static BookingModel ToModel(this BookingEntity entity)
        {
            BookingModel result = new BookingModel(entity.Id, DateTime.Parse(entity.CheckIn), DateTime.Parse(entity.CheckOut),
                entity.Cost, new List<RoomModel>(), new List<GuestModel>(), new List<ServiceModel>());
            CheckSkipModels(result, result.Rooms, entity.Rooms, null);
            CheckSkipModels(result, result.Guests, entity.Guests, null);
            CheckSkipModels(result, result.Services, entity.Services, null);

            return result;
        }
        private static BookingModel ToModel(this BookingEntity entity, Model skipModel)
        {
            BookingModel result = new BookingModel(entity.Id, DateTime.Parse(entity.CheckIn), DateTime.Parse(entity.CheckOut),
                 entity.Cost, new List<RoomModel>(), new List<GuestModel>(), new List<ServiceModel>());
            CheckSkipModels(result, result.Rooms, entity.Rooms, skipModel);
            CheckSkipModels(result, result.Guests, entity.Guests, skipModel);
            CheckSkipModels(result, result.Services, entity.Services, skipModel);

            return result;
        }

        public static StaffModel ToModel(this StaffEntity entity)
        {
            StaffModel result = new StaffModel(entity.Id, entity.Name, DateOnly.Parse(entity.BirthDate), null,
                entity.Rating, new List<UserFeedbackModel>(), null);
            CheckSkipModel(result.Gender, entity.Gender, null);
            CheckSkipModels(result, result.Feedbacks, entity.Feedbacks, null);
            CheckSkipModel(result.PositionType, entity.PositionType, null);
            return result;
        }
        private static StaffModel ToModel(this StaffEntity entity, Model skipModel)
        {
            StaffModel result = new StaffModel(entity.Id, entity.Name, DateOnly.Parse(entity.BirthDate), null,
                entity.Rating, new List<UserFeedbackModel>(), null); 
            CheckSkipModel(result.Gender, entity.Gender, skipModel);
            CheckSkipModels(result, result.Feedbacks, entity.Feedbacks, skipModel);
            CheckSkipModel(result.PositionType, entity.PositionType, skipModel);
            return result;
        }

        public static PositionTypeModel ToModel(this PositionTypeEntity entity)
        {
            PositionTypeModel result = new PositionTypeModel(entity.Id, entity.Name, new List<StaffModel>);
            CheckSkipModels(result, result.Staff, entity.Staff, null);
            return result;
        }
        private static PositionTypeModel ToModel(this PositionTypeEntity entity, Model skipModel)
        {
            PositionTypeModel result = new PositionTypeModel(entity.Id, entity.Name, new List<StaffModel>);
            CheckSkipModels(result, result.Staff, entity.Staff, skipModel);
            return result;
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
                Bookings = new List<BookingEntity>(),
                Number = model.Number,
                Capacity = model.Capacity,
                Price = model.Price,
                Hotel = null,
                HotelId = model.Hotel.Id,
                RoomType = null,
                RoomTypeId = model.RoomType.Id
            };
            CheckSkipEntity(result.View, model.View, null);
            CheckSkipEntities(result, result.Bookings, model.Bookings, null);
            CheckSkipEntity(result.Hotel, model.Hotel, null);
            CheckSkipEntity(result.RoomType, model.RoomType, null);
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
                Bookings = new List<BookingEntity>(),
                Number = model.Number,
                Capacity = model.Capacity,
                Price = model.Price,
                Hotel = null,
                HotelId = model.Hotel.Id,
                RoomType = null,
                RoomTypeId = model.RoomType.Id
            };
            CheckSkipEntity(result.View, model.View, skipEntity);
            CheckSkipEntities(result, result.Bookings, model.Bookings, skipEntity);
            CheckSkipEntity(result.Hotel, model.Hotel, skipEntity);
            CheckSkipEntity(result.RoomType, model.RoomType, skipEntity);

            return result;
        }

        public static RoomTypeEntity ToEntity(this RoomTypeModel model)
        {
           
            RoomTypeEntity result = new RoomTypeEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Rooms = new List<RoomEntity>()
            };
            CheckSkipEntities(result, result.Rooms, model.Rooms, null);
            return result;
        }
       

        private static RoomTypeEntity ToEntity(this RoomTypeModel model, Entity skipEntity) 
        {
            RoomTypeEntity result = new RoomTypeEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Rooms = new List<RoomEntity>()
            };
            CheckSkipEntities(result, result.Rooms, model.Rooms, skipEntity);
            return result;
        }

        public static ServiceEntity ToEntity(this ServiceModel model)
        {
            ServiceEntity result = new ServiceEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                ServiceType = null,
                ServiceTypeId = model.ServiceType.Id,
                Hotels = new List<HotelEntity>()
            };
            CheckSkipEntity(result.ServiceType, model.ServiceType, null);
            CheckSkipEntities(result, result.Hotels, model.Hotels, null);

            return result;
        }


        private static ServiceEntity ToEntity(this ServiceModel model, Entity skipEntity)
        {
            ServiceEntity result = new ServiceEntity() 
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                ServiceType = null,
                ServiceTypeId = model.ServiceType.Id,
                Hotels = new List<HotelEntity>()
            };
            CheckSkipEntity(result.ServiceType, model.ServiceType, skipEntity);
            CheckSkipEntities(result, result.Hotels, model.Hotels, skipEntity);

            return result;
        }


        public static ServiceTypeEntity ToEntity(this ServiceTypeModel model)
        {
            ServiceTypeEntity result = new ServiceTypeEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Services = new List<ServiceEntity>()
            };
            CheckSkipEntities(result, result.Services, model.Services, null);
            return result;
        }

        private static ServiceTypeEntity ToEntity(this ServiceTypeModel model, Entity skipEntity)
        {
            ServiceTypeEntity result = new ServiceTypeEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Services = new List<ServiceEntity>()
            };
            CheckSkipEntities(result, result.Services, model.Services, skipEntity);
            return result;
        }

        public static RoomViewEntity ToEntity(this RoomViewModel model)
        {
            RoomViewEntity result = new RoomViewEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Rooms = new List<RoomEntity>()
            };
            CheckSkipEntities(result, result.Rooms, model.Rooms, null);
            return result;
        }

        private static RoomViewEntity ToEntity(this RoomViewModel model, Entity skipEntity)
        {
            RoomViewEntity result = new RoomViewEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Rooms = new List<RoomEntity>()
            };
            CheckSkipEntities(result, result.Rooms, model.Rooms, skipEntity);
            return result;
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
            GenderEntity result = new GenderEntity()
            {
                Id = model.Id,
                Name = model.Gender.ToString(),
                Users = new List<UserEntity>()
            };
            CheckSkipEntities(result, result.Users, model.Users, null);
            return result;
        }
        private static GenderEntity ToEntity(this GenderModel model, Entity skipEntity)
        {
            GenderEntity result = new GenderEntity()
            {
                Id = model.Id,
                Name = model.Gender.ToString(),
                Users = new List<UserEntity>()
            };
            CheckSkipEntities(result, result.Users, model.Users, skipEntity);
            return result;
        }

        public static UserFeedbackEntity ToEntity(this UserFeedbackModel model)
        {
            UserFeedbackEntity result = new UserFeedbackEntity()
            {
                Id = model.Id,
                FeedbackType = model.UserFeedbackType.ToString(),
                User = null,
                UserId = model.User.Id
            };
            CheckSkipEntity(result.User, model.User, null);
            return result;
        }
        public static UserFeedbackEntity ToEntity(this UserFeedbackModel model, Entity skipEntity)
        {
            UserFeedbackEntity result = new UserFeedbackEntity()
            {
                Id = model.Id,
                FeedbackType = model.UserFeedbackType.ToString(),
                User = null,
                UserId = model.User.Id
            };
            CheckSkipEntity(result.User, model.User, skipEntity);
            return result;
        }

        public static GuestEntity ToEntity(this GuestModel model)
        {
            GuestEntity result = new GuestEntity()
            {
                Id = model.Id,
                Name = model.Name,
                BirthDate = model.BirthDate.ToString(),
                Gender = model.Gender.ToEntity(),
                Bookings = new List<BookingEntity>()
            };
            CheckSkipEntity(result.Gender, model.Gender, null);
            CheckSkipEntities(result, result.Bookings, model.Bookings, null);
            return result;
        }
        private static GuestEntity ToEntity(this GuestModel model, Entity skipEntity)
        {
            GuestEntity result = new GuestEntity()
            {
                Id = model.Id,
                Name = model.Name,
                BirthDate = model.BirthDate.ToString(),
                Gender = null,
                Bookings = new List<BookingEntity>()
            };
            CheckSkipEntity(result.Gender, model.Gender, skipEntity);
            CheckSkipEntities(result, result.Bookings, model.Bookings, skipEntity);
            return result;
        }

        public static BookingEntity ToEntity(this BookingModel model)
        {
            BookingEntity result = new BookingEntity()
            {
                CheckIn = model.CheckIn.ToString(),
                CheckOut = model.CheckOut.ToString(),
                Id = model.Id,
                Cost = model.Cost,
                Guests = new List<GuestEntity>(),
                Rooms = new List<RoomEntity>()
            };
            CheckSkipEntities(result, result.Guests, model.Guests, null);
            CheckSkipEntities(result, result.Rooms, model.Rooms, null);
            return result;
        }

        private static BookingEntity ToEntity(this BookingModel model, Entity skipEntity)
        {
            BookingEntity result = new BookingEntity()
            {
                CheckIn = model.CheckIn.ToString(),
                CheckOut = model.CheckOut.ToString(),
                Id = model.Id,
                Cost = model.Cost,
                Guests = new List<GuestEntity>(),
                Rooms = new List<RoomEntity>()
            };
            CheckSkipEntities(result, result.Guests, model.Guests, skipEntity);
            CheckSkipEntities(result, result.Rooms, model.Rooms, skipEntity);
            return result;
        }

        public static StaffEntity ToEntity(this StaffModel model)
        {
            StaffEntity result = new StaffEntity()
            {
                Id = model.Id,
                BirthDate = model.BirthDate.ToString(),
                Name = model.Name,
                Gender = null,
                GenderId = model.Gender.Id,
                Rating = model.Rating,
                PositionType = null,
                PositionId = model.PositionType.Id,
                Feedbacks = new List<UserFeedbackEntity>()
            };
            CheckSkipEntity(result.Gender, model.Gender, null);
            CheckSkipEntity(result.PositionType, model.PositionType, null);
            CheckSkipEntities(result, result.Feedbacks, model.Feedbacks, null);
            return result;
        }
        public static StaffEntity ToEntity(this StaffModel model, Entity skipEntity)
        {
            StaffEntity result = new StaffEntity()
            {
                Id = model.Id,
                BirthDate = model.BirthDate.ToString(),
                Name = model.Name,
                Gender = null,
                GenderId = model.Gender.Id,
                Rating = model.Rating,
                PositionType = null,
                PositionId = model.PositionType.Id,
                Feedbacks = new List<UserFeedbackEntity>()
            };
            CheckSkipEntity(result.Gender, model.Gender, skipEntity);
            CheckSkipEntity(result.PositionType, model.PositionType, skipEntity);
            CheckSkipEntities(result, result.Feedbacks, model.Feedbacks, skipEntity);
            return result;
        }

        public static PositionTypeEntity ToEntity(this PositionTypeModel model)
        {
            PositionTypeEntity result = new PositionTypeEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Staff = new List<StaffEntity>()
            };
            CheckSkipEntities(result, result.Staff, model.Staff, null);
            return result;
        }
        public static PositionTypeEntity ToEntity(this PositionTypeModel model, Entity skipEntity)
        {
            PositionTypeEntity result = new PositionTypeEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Staff = new List<StaffEntity>()
            };
            CheckSkipEntities(result, result.Staff, model.Staff, skipEntity);
            return result;
        }

        #endregion USER

        #endregion MODEL_TO_ENTITY
    }
}