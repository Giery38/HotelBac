using Hotel.Core.Models;
using Hotel.Core.Models.Common;
using Hotel.Core.Models.Hotel;
using Hotel.Data.Models;
using Hotel.Data.Models.Hotel;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Converters
{
    public static class EntityConverter 
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
                case GuestEntity:
                    GuestEntity guestEntity = entity as GuestEntity;
                    return guestEntity.ToModel();
                case BookingEntity:
                    BookingEntity bookingEntity = entity as BookingEntity;
                    return bookingEntity.ToModel();
                case AdminEntity:
                    AdminEntity adminEntity =   entity as AdminEntity;
                    return adminEntity.ToModel();
                default:
                    return null;
            }
        }
        #region HOTEL
        public static HotelModel ToModel(this HotelEntity entity)
        {
            return new HotelModel(entity.Id, entity.Name, entity.Description,
                entity.Address, entity.Phone, entity.Stars, entity.Photos);
        }
        public static RoomModel ToModel(this RoomEntity entity)
        {
            return new RoomModel(entity.Id, entity.Number, entity.Price, entity.RoomType.ToModel(),
                entity.Description, entity.Occupancy, entity.Photos,
                entity.Hotel.ToModel(), entity.Bookings.ConvertAll(i => i.ToModel()));
        }
        public static RoomTypeModel ToModel(this RoomTypeEntity entity)
        {
            return new RoomTypeModel(entity.Id, entity.Value, entity.Rooms.ConvertAll(i => i.ToModel()));
        }
        #endregion
        #region USER
        public static GuestModel ToModel(this GuestEntity entity)
        {
            return new GuestModel(entity.Id, entity.Password, entity.Login,
                entity.Name, entity.Phone, DateOnly.Parse(entity.BirthDay),
                entity.PassportNumber, entity.Bookings.ConvertAll(i => i.ToModel()));
        }
        public static BookingModel ToModel(this BookingEntity entity)
        {
            return new BookingModel(entity.Id, DateTime.Parse(entity.CheckIn),
                DateTime.Parse(entity.CheckOut), entity.Value, entity.Paid,
                entity.Rooms.ConvertAll(i => i.ToModel()), entity.Guests.ConvertAll(i => i.ToModel()));
        }
        public static AdminModel ToModel(this AdminEntity entity)
        {
            return new AdminModel(entity.Id, entity.Password, entity.Login);
        }
        #endregion
        #endregion
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
                case GuestModel:
                    GuestModel guestModel = model as GuestModel;
                    return guestModel.ToEntity();
                case BookingModel:
                    BookingModel bookingModel = model as BookingModel;
                    return bookingModel.ToEntity();
                case AdminModel:
                    AdminModel adminModel = model as AdminModel;
                    return adminModel.ToEntity();
                default:
                    return null;                    
            }
        }
        #region HOTEL
        public static HotelEntity ToEntity(this HotelModel model)
        {
            return new HotelEntity()
            {
                Id = model.Id,
                Address = model.Address,
                Description = model.Description,
                Name = model.Name,
                Phone = model.Phone,
                Photos = model.Photos,
                Rooms = model.Rooms.ConvertAll(i => i.ToEntity()),
                Stars = model.Stars
            };

        }
        public static RoomEntity ToEntity(this RoomModel model)
        {
            return new RoomEntity()
            {
                Id = model.Id,
                Bookings = model.Bookings.ConvertAll(i => i.ToEntity()),
                Photos = model.Photos,
                Description = model.Description,
                Number = model.Number,
                Occupancy = model.Occupancy,
                Price = model.Price,
                RoomType = model.RoomType.ToEntity(),
                Hotel = model.Hotel.ToEntity(),
                HotelId = model.Hotel.Id,
                RoomTypeId = model.RoomType.Id
            };
        }
        public static RoomTypeEntity ToEntity(this RoomTypeModel model)
        {
            return new RoomTypeEntity()
            {
                Id = model.Id,
                Value = model.Value,
                Rooms = model.Rooms.ConvertAll(i => i.ToEntity())
            };
        }
        #endregion
        #region USER
        public static GuestEntity ToEntity(this GuestModel model)
        {
            return new GuestEntity()
            {
                BirthDay = model.BirthDay.ToString(),
                Email = model.Email,
                Id = model.Id,
                Login = model.Login,
                Name = model.Name,
                Phone = model.Phone,
                Password = model.Password,
                Bookings = model.Bookings.ConvertAll(i => i.ToEntity()),
                PassportNumber = model.PassportNumber
            };
        }
        public static BookingEntity ToEntity(this BookingModel model)
        {
            return new BookingEntity()
            {
                CheckIn = model.CheckIn.ToString(),
                CheckOut = model.CheckOut.ToString(),
                Id = model.Id,
                Paid = model.Paid,
                Value = model.Value,
                Guests = model.Guests.ConvertAll(i => i.ToEntity()),
                Rooms = model.Rooms.ConvertAll(i => i.ToEntity())
            };
        }
        public static AdminEntity ToEntity(this AdminModel model)
        {
            return new AdminEntity() { Id = model.Id, Login = model.Login, Password = model.Password };
        }
        #endregion
        #endregion
    }
}
    