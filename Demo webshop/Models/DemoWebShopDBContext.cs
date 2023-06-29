using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo_webshop.Models
{
    public class DemoWebShopDBContext: IdentityDbContext
    {

        public DemoWebShopDBContext(DbContextOptions<DemoWebShopDBContext> options): base(options)
        {
        }

        public DemoWebShopDBContext()
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("FakeWebDatabase.db");
            }
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            var user = new ApplicationUser
            {
                Id = "bc787601-3197-4180-8587-9f0433cade28",
                UserName = "demo@example.com",
                NormalizedUserName = "DEMO@EXAMPLE.COM",
                Email = "demo@example.com",
                NormalizedEmail = "DEMO@EXAMPLE.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEJDsJ11VXYg4gZRdj4QjrgjqwoJjs05G9sDQFZWzUJU0LcukM7syxdUrcOtIihvfxQ==",
                EmailConfirmed = false,
                LockoutEnabled = false
            };

            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "ffbff311-d6ba-4a68-870d-81ae9c701b92", Name = "manager", NormalizedName = "MANAGER"
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "bc787601-3197-4180-8587-9f0433cade28", RoleId = "ffbff311-d6ba-4a68-870d-81ae9c701b92" }
            );

            var genreList = new Genre[]
            {
                new Genre{
                    GenreName = "Adventure",
                    Description = "Games that gives you almost free will no explore the world",
                    GenreId= 1
                    },
                new Genre{
                    GenreName = "Shooter",
                    Description = "Games in wich you use fire guns to advance",
                    GenreId= 2
                    },
                new Genre{
                    GenreName = "Racing",
                    Description = "Racing games are a video game genre in which the player participates in a racing competition.",
                    GenreId= 3
                    },
                new Genre{
                    GenreName = "Horror",
                    Description = "A horror game is a video game genre centered on horror fiction and typically designed to scare the player.",
                    GenreId= 4
                    }
            };
            modelBuilder.Entity<Genre>().HasData(genreList);

            var productList = new Product[]
            {
                new Product{
                    Name = "Assassin's Creed Mirage",
                    InStock = true,
                    GenreId = 1,
                    ProductId= 1,
                    Publisher = "Ubisoft",
                    ReleaseDate = new DateTime(2024, 1, 1),
                    ESRB = "16+",
                    IsGameOfTheWeek = true,
                    Price = 59.99m,
                    ImageUrl = "https://live.staticflickr.com/65535/52835737966_a3fbe0b8de_o.jpg",
                    ImageThumbnailUrl = "https://live.staticflickr.com/65535/52835138852_79f3dfce59_o.png",
                    ShortDescription = "In Assassin's Creed Mirage, you are Basim, a cunning street thief with nightmarish visions seeking answers and justice.",
                    LongDescription = "Discover a narrative-driven action-adventure experience that follows the transformation of a defiant young man into a refined Master Assassin with a conflicted destiny. Meet an inspiring cast of characters who will shape Basim’s destiny and may be more than what they seem…"
                    },
                new Product{
                    Name = "Doom Eternal",
                    InStock = true,
                    GenreId = 2,
                    ProductId= 2,
                    Publisher = "Ubisoft",
                    ReleaseDate = new DateTime(2019, 3, 19),
                    ESRB = "16+",
                    IsGameOfTheWeek = false,
                    Price = 39.99m,
                    ImageUrl = "https://live.staticflickr.com/65535/52835922519_d3ff2ac8a5_o.jpg",
                    ImageThumbnailUrl = "https://live.staticflickr.com/65535/52836122545_5600cb1b82_o.png",
                    ShortDescription = "Developed by id Software and Panic Button, DOOM Eternal is the direct sequel to DOOM®, winner of The Game Awards' Best Action Game of 2016",
                    LongDescription = "Hell’s armies have invaded Earth. Become the Slayer in an epic single-player campaign to conquer demons across dimensions and stop the final destruction of humanity. The only thing they fear... is you."
                    },
                new Product{
                    Name = "Forza Horizon 5",
                    InStock = false,
                    GenreId = 3,
                    ProductId= 3,
                    Publisher = "Xbox Game Studio - Playground Games",
                    ReleaseDate = new DateTime(2021, 11, 8),
                    ESRB = "12+",
                    IsGameOfTheWeek = false,
                    Price = 59.99m,
                    ImageUrl = "https://live.staticflickr.com/65535/52835143902_31d95896a2_o.png",
                    ImageThumbnailUrl = "https://live.staticflickr.com/65535/52836143860_597b9935bc_o.png",
                    ShortDescription = "Your Ultimate Horizon Adventure awaits! Explore the vibrant open world landscapes of Mexico with limitless, fun driving action in the world's greatest cars.",
                    LongDescription = "Forza Horizon 5 is a racing video game set in an open world environment based in a fictional representation of Mexico. The game has the largest map in the entire Forza Horizon series, being 50% larger than its predecessor, Forza Horizon 4, while also having the highest point in the Horizon series."
                    },
                new Product{
                    Name = "Gears 5",
                    InStock = true,
                    GenreId = 2,
                    ProductId= 4,
                    Publisher = "Xbox Game Studio - The Coalition",
                    ReleaseDate = new DateTime(2019, 9, 9),
                    ESRB = "16+",
                    IsGameOfTheWeek = false,
                    Price = 39.99m,
                    ImageUrl = "https://live.staticflickr.com/65535/52836143850_f5fb955bac_o.jpg",
                    ImageThumbnailUrl = "https://live.staticflickr.com/65535/52836165003_230a7216fc_o.png",
                    ShortDescription = "From one of gaming's most acclaimed sagas, Gears 5 relaunches with brand new features. Campaign: With all-out war descending",
                    LongDescription = "Gears 5 is a 2019 third-person shooter video game developed by The Coalition and published by Xbox Game Studios for Windows, Xbox One, and Xbox Series X/S. It is the fifth main installment of the Gears of War series and the sequel to Gears of War 4. Gears 5 follows the story of Kait Diaz, who is on a journey to find out the origin of the Locust Horde, the main antagonistic faction of the Gears of War series."
                    },
                new Product{
                    Name = "Hellblade",
                    InStock = false,
                    GenreId = 4,
                    ProductId= 5,
                    Publisher = "Xbox Game Studio - Ninja Theory",
                    ReleaseDate = new DateTime(2018, 4, 18),
                    ESRB = "16+",
                    IsGameOfTheWeek = false,
                    Price = 39.99m,
                    ImageUrl = "https://live.staticflickr.com/65535/52835737961_34910b536f_o.jpg",
                    ImageThumbnailUrl = "https://live.staticflickr.com/65535/52835716221_3376aee0e4_o.png",
                    ShortDescription = "Created in collaboration with neuroscientists and people who experience psychosis, Hellblade: Senua's Sacrifice will pull you deep into Senua's mind.",
                    LongDescription = "Hellblade: Senua's Sacrifice is a 2017 action-adventure game developed and published by the British video game development studio Ninja Theory. Set in a dark fantasy world inspired by Norse mythology and Celtic culture, the game follows Senua, a Pict warrior who must make her way to Helheim by defeating otherworldly entities and facing their challenges, in order to rescue the soul of her dead lover from the goddess Hela."
                    },
                new Product{
                    Name = "Resident Evil 4",
                    InStock = true,
                    GenreId = 4,
                    ProductId= 6,
                    Publisher = "Capcom",
                    ReleaseDate = new DateTime(2023, 3, 23),
                    ESRB = "16+",
                    IsGameOfTheWeek = true,
                    Price = 59.99m,
                    ImageUrl = "https://live.staticflickr.com/65535/52835737956_e188db686a_o.jpg",
                    ImageThumbnailUrl = "https://live.staticflickr.com/65535/52836122530_0c72b0d2ab_o.png",
                    ShortDescription = "Featuring modernized gameplay, a reimagined storyline, and vividly detailed graphics, Resident Evil 4 marks the rebirth of an industry juggernaut. ",
                    LongDescription = "Resident Evil 4 is a remake of the 2005 original Resident Evil 4.\r\n\r\nReimagined for 2023 to bring state-of-the-art survival horror.\r\n\r\nResident Evil 4 preserves the essence of the original game, while introducing modernized gameplay, a reimagined storyline, and vividly detailed graphics to make this the latest survival horror game where life and death, terror and catharsis intersect."
                    },
            };
            modelBuilder.Entity<Product>().HasData(productList);
        }


        }
}
