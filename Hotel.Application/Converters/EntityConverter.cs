using Hotel.Core.Models;
using Hotel.Core.Models.Hotel;
using Hotel.Core.Models.Users.Admins;
using Hotel.Core.Models.Users.Guests;
using Hotel.DataAccess.Postgres.Models;
using Hotel.DataAccess.Postgres.Models.Hotel;
using Hotel.DataAccess.Postgres.Models.Users.Admins;
using Hotel.DataAccess.Postgres.Models.Users.Guests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Converters
{
    internal static class EntityConverter
    {
        #region HOTEL
        public static HotelModel ToModel(this HotelEntity entity)
        {
            return new HotelModel(entity.Name, entity.Description, entity.Address, entity.Phone, entity.Stars, entity.Photos);   
        }
        public static RoomModel ToModel(this RoomEntity entity)
        {
            return new RoomModel(entity.Number, entity.Price, entity.RoomType.ToModel(), entity.Description, entity.Occupancy, entity.Photos, entity.Hotel.ToModel(), entity.Bookings.ConvertAll(i => i.ToModel()));
        }
        public static RoomTypeModel ToModel(this RoomTypeEntity entity)
        {
            return new RoomTypeModel(entity.Value, entity.Rooms.ConvertAll(i => i.ToModel()));
        }
        #endregion
        #region USER
        public static GuestModel ToModel(this GuestEntity entity)
        {
            return new GuestModel(entity.Password, entity.Login, entity.Name, entity.Phone, DateOnly.Parse(entity.BirthDay), entity.PassportNumber, entity.Bookings.ConvertAll(i => i.ToModel()));
        }
        public static BookingModel ToModel(this BookingEntity entity)
        {
            return new BookingModel(DateTime.Parse(entity.CheckIn), DateTime.Parse(entity.CheckOut), entity.Value, entity.Paid, entity.Rooms.ConvertAll(i => i.ToModel()), entity.Guests.ConvertAll(i => i.ToModel()));
        }
        public static AdminModel ToModel(this AdminEntity entity)
        {
            return new AdminModel(entity.Password, entity.Login);
        } 
        #endregion
    }
}
