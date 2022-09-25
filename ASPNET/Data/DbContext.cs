using ASPNET.Models;
using Database.Models;

namespace ASPNET.Data
{
    public class DbContext
    {
        public static IEnumerable<EventType> EventTypes { get; set; }

        public static IEnumerable<Event> GetEvents()
        {
            EventType sportT = new EventType()
            {
                Id = 1,
                Name = "Sports"
            };
            EventType filmT = new EventType()
            {
                Id = 2,
                Name = "Films"
            };

            EventTypes = new EventType[]
            {
                sportT,
                filmT
            };

            Event e1 = new Event()
            {
                Id = 1,
                Title = "Football Game",
                Text = "nunc non blandit massa enim nec dui nunc mattis enim ut tellus elementum sagittis vitae et leo duis ut diam quam nulla porttitor massa id neque aliquam vestibulum morbi blandit cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget gravida cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus mauris vitae ultricies leo integer malesuada nunc vel risus commodo viverra maecenas accumsan lacus vel facilisis volutpat est velit egestas dui id ornare arcu odio ut sem nulla pharetra diam sit amet nisl suscipit adipiscing bibendum est ultricies integer quis auctor elit sed vulputate mi",
                CreationTime = DateTime.Now,
                EventTime = new DateTime(2022, 12, 3),
                Price = 100
            };

            Event e2 = new Event()
            {
                Id = 2,
                Title = "Basketball Game",
                Text = "pharetra sit amet aliquam id diam maecenas ultricies mi eget mauris pharetra et ultrices neque ornare aenean euismod elementum nisi quis eleifend quam adipiscing vitae proin sagittis nisl rhoncus mattis rhoncus urna neque viverra justo nec ultrices dui sapien eget mi proin sed libero enim sed faucibus turpis in eu mi bibendum neque egestas congue quisque egestas diam in arcu cursus euismod quis viverra nibh cras pulvinar mattis nunc sed blandit libero volutpat sed cras ornare arcu dui vivamus arcu felis bibendum ut tristique et egestas quis ipsum suspendisse ultrices gravida dictum fusce ut placerat orci nulla pellentesque dignissim enim",
                CreationTime = DateTime.Now,
                EventTime = new DateTime(2022, 10, 12),
                Price = 300
            };

            Event e3 = new Event()
            {
                Id = 3,
                Title = "Marvel film",
                Text= "lacus sed viverra tellus in hac habitasse platea dictumst vestibulum rhoncus est pellentesque elit ullamcorper dignissim cras tincidunt lobortis feugiat vivamus at augue eget arcu dictum varius duis at consectetur lorem donec massa sapien faucibus et molestie ac feugiat sed lectus vestibulum mattis ullamcorper velit sed ullamcorper morbi tincidunt ornare massa eget egestas purus viverra accumsan in nisl nisi scelerisque eu ultrices vitae auctor eu augue ut lectus arcu bibendum at varius vel pharetra vel turpis nunc eget lorem dolor sed viverra ipsum nunc aliquet bibendum enim facilisis gravida neque convallis a cras semper auctor neque vitae tempus quam pellentesque",
                CreationTime = DateTime.Now,
                EventTime = new DateTime(2022, 9, 26),
                Price = 50
            };

            Event e4 = new Event()
            {
                Id = 4,
                Title = "Football film",
                Text= "erat pellentesque adipiscing commodo elit at imperdiet dui accumsan sit amet nulla facilisi morbi tempus iaculis urna id volutpat lacus laoreet non curabitur gravida arcu ac tortor dignissim convallis aenean et tortor at risus viverra adipiscing at in tellus integer feugiat scelerisque varius morbi enim nunc faucibus a pellentesque sit amet porttitor eget dolor morbi non arcu risus quis varius quam quisque id diam vel quam elementum pulvinar etiam non quam lacus suspendisse faucibus interdum posuere lorem ipsum dolor sit amet consectetur adipiscing elit duis tristique sollicitudin nibh sit amet commodo nulla facilisi nullam vehicula ipsum a arcu cursus vitae",
                CreationTime = DateTime.Now,
                EventTime = new DateTime(2022, 11, 14),
                Price = 100
            };

            e1.Types.Add(sportT);
            e2.Types.Add(sportT);
            e3.Types.Add(filmT);
            e4.Types.Add(filmT);
            e4.Types.Add(sportT);

            sportT.Events.Add(e1);
            sportT.Events.Add(e2);
            sportT.Events.Add(e4);

            filmT.Events.Add(e3);
            filmT.Events.Add(e4);

            return new Event[]
            {
                e1,
                e2,
                e3,
                e4
            };
        }
    }
}
