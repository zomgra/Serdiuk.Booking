using Serdiuk.Booking.Domain;

namespace Serdiuk.Booking.Infrastructure.Persistance
{
    public class ApplicationDbContextSeed
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            var numbers = new List<HotelNumber>()
                {
                    new HotelNumber("Lux-1", "https://panoramacity.ru/wp-content/uploads/2020/07/3V9A6982.jpg", NumberType.Lux, 550),
                    new HotelNumber("Econom-1", "https://www.palladaran.ru/uploads/images/ekonom-nomer.jpg", NumberType.Econom, 200),
                    new HotelNumber("Econom-2", "https://cronhotel.ru/images/page-rooms/econom/modal/econom-1.jpg", NumberType.Econom, 220),
                    new HotelNumber("Lux-2", "https://vedenskyhotel.ru/wp-content/uploads/2017/11/00006standart_room_vedensky-2.jpg", NumberType.Lux, 500),
                    new HotelNumber("LuxPlus-1", "https://kidpassage.com/images/publications/images/1265_room-type-3.jpg", NumberType.LuxPlus, 990),
                    new HotelNumber("Econom-3", "https://hotel-tourist.kiev.ua/ru/assets/photo/rooms/economy-single-room/tourist-hotel-economy-single%20(2).jpg", NumberType.Econom, 100),
                };
            var hotels = new List<Hotel>()
            {
                new Hotel("Hotel-Super",  "New-York Str. 3", "https://www.ahstatic.com/photos/1276_ho_00_p_1024x768.jpg", "В отель включает в себя [All Inclusive]") {HotelNumbers = new List<HotelNumber>(){numbers[0],numbers[3], numbers[4] } },
               // new Hotel{Name = "Hotel-Super", Street = "New-York Str. 3", HotelNumbers = new List<HotelNumber>(){numbers[0],numbers[3], numbers[4] } },
                new Hotel( "Econom-Hotel", "Haharina Str. 4", "https://www.h-hotels.com/_Resources/Persistent/0/1/a/4/01a400d0047f4b7599631797fc27ceabf9e68db3/aussenansicht-nacht-03-h4-hotel-berlin-alexanderplatz-2400x1113.jpg", "В отель входит только завтрак"){HotelNumbers =  new List<HotelNumber>(){numbers[1], numbers[2],numbers[5] } },
            };
            if (!context.Hotels.Any() && !context.HotelNumbers.Any())
            {
                //context.AddRange(numbers);
                context.AddRange(hotels);
                context.SaveChanges();
            }
        }
    }
}
