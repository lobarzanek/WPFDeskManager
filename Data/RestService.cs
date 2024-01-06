using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Models.DTO;
using WPFDeskManager.Utilities;

namespace WPFDeskManager.Data
{
    public class RestService
    {
        public RestService()
        {

        }

        #region Item Methods

        public async Task<ObservableCollection<Item>> GetItemsAsync()
        {
            await Task.Delay(500);

            var _items = new ObservableCollection<Item>() {
                new Item()
                {
                    Id = 1,
                    Name = "Mouse #1",
                    AddDate = new DateTime(2023, 12, 21, 5, 10, 20),
                    SerialNumber = "abc123def456",
                    Status = ItemStatus.Free,
                    Type = ItemType.Mouse,
                    OwnerId = 1,
                    OwnerName = "User #1",
                    BrandId = 1,
                    BrandName = "Brand #1",
                    DeskId = null,
                    DeskName = null,
                },
                new Item()
                {
                    Id = 2,
                    Name = "Mouse #2",
                    AddDate = new DateTime(2023, 12, 22, 6, 30, 28),
                    SerialNumber = "m8c32nac09c",
                    Status = ItemStatus.Used,
                    Type = ItemType.Mouse,
                    OwnerId = 2,
                    OwnerName = "User #2",
                    BrandId = 2,
                    BrandName = "Brand #2",
                    DeskId = 1,
                    DeskName = "Desk #1",
                },
                new Item()
                {
                    Id = 3,
                    Name = "Keyboard #3",
                    AddDate = new DateTime(2023, 12, 22, 8, 30, 28),
                    SerialNumber = "nc8cqfhd9q",
                    Status = ItemStatus.Used,
                    Type = ItemType.Keyboard,
                    OwnerId = 2,
                    OwnerName = "User #2",
                    BrandId = 2,
                    BrandName = "Brand #2",
                    DeskId = 1,
                    DeskName = "Desk #1",
                },new Item()
                {
                    Id = 4,
                    Name = "Mouse #4",
                    AddDate = new DateTime(2023, 12, 21, 5, 10, 20),
                    SerialNumber = "abc123def456",
                    Status = ItemStatus.Free,
                    Type = ItemType.Mouse,
                    OwnerId = 1,
                    OwnerName = "User #1",
                    BrandId = 1,
                    BrandName = "Brand #1",
                    DeskId = null,
                    DeskName = null,
                },
                new Item()
                {
                    Id = 5,
                    Name = "Mouse #5",
                    AddDate = new DateTime(2023, 12, 22, 6, 30, 28),
                    SerialNumber = "m8c32nac09c",
                    Status = ItemStatus.Used,
                    Type = ItemType.Mouse,
                    OwnerId = 2,
                    OwnerName = "User #2",
                    BrandId = 2,
                    BrandName = "Brand #2",
                    DeskId = 1,
                    DeskName = "Desk #1",
                },
                new Item()
                {
                    Id = 6,
                    Name = "Keyboard #6",
                    AddDate = new DateTime(2023, 12, 22, 8, 30, 28),
                    SerialNumber = "nc8cqfhd9q",
                    Status = ItemStatus.Used,
                    Type = ItemType.Keyboard,
                    OwnerId = 2,
                    OwnerName = "User #2",
                    BrandId = 2,
                    BrandName = "Brand #2",
                    DeskId = 1,
                    DeskName = "Desk #1",
                }
            };

            return _items;
        }
        public async Task<Item> GetItemByIdAsync(int id)
        {
            await Task.Delay(500);
            var _items = await GetItemsAsync();

            return _items.Where(e => e.Id == id).FirstOrDefault();
        }
        public async Task<bool> AddItemAsync(AddItemDto addItemDto)
        {
            await Task.Delay(2000);
            return true;
        }
        public async Task<bool> UpdateItemAsync(UpdateItemDto updateItemDto)
        {
            await Task.Delay(1000);
            return true;
        }

        #endregion

        #region Building Methods

        public async Task<ObservableCollection<Building>> GetBuildingsAsync()
        {
            await Task.Delay(300);

            var _buildings = new ObservableCollection<Building>
            {
                new Building
                {
                    Id = 1,
                    Name = "Building #1",
                },
                new Building
                {
                    Id = 2,
                    Name = "Building #2",
                },
                new Building
                {
                    Id = 3,
                    Name = "Building #3",
                },
                new Building
                {
                    Id = 4,
                    Name = "Building #4",
                },
                new Building
                {
                    Id = 5,
                    Name = "Building #5",
                },
            };

            return _buildings;
        }
        public async Task<Building> GetBuildingById(int id)
        {
            await Task.Delay(300);

            var _building = await GetBuildingsAsync();

            return _building.Where(e => e.Id == id).FirstOrDefault();
        }
        public async Task<bool> AddBuildingAsync(AddBuildingDto building)
        {
            await Task.Delay(2000);
            return true;
        }
        public async Task<bool> UpdateBuilding(Building building)
        {
            await Task.Delay(300);

            return true;
        }

        #endregion

        #region Brand Methods

        public async Task<ObservableCollection<Brand>> GetBrandsAsync()
        {
            await Task.Delay(1000);
            var _brands = new ObservableCollection<Brand>()
            {
                new Brand
                {
                    Id = 1,
                    Name = "Brand #1"
                },
                new Brand
                {
                    Id = 2,
                    Name = "Brand #2"
                },
                new Brand
                {
                    Id = 3,
                    Name = "Brand #3"
                },
                new Brand
                {
                    Id = 4,
                    Name = "Brand #4"
                },

            };

            return _brands;
        }
        public async Task<Brand> GetBrandById(int id)
        {
            await Task.Delay(300);

            var _brand = await GetBrandsAsync();

            return _brand.Where(e => e.Id == id).FirstOrDefault();
        }
        public async Task<bool> AddBrandAsync(AddBrandDto brand)
        {
            await Task.Delay(2000);
            return true;
        }
        public async Task<bool> UpdateBrand(Brand brand)
        {
            await Task.Delay(300);

            return true;
        }

        #endregion

        #region Desk Status Methods

        public async Task<ObservableCollection<DeskStatus>> GetDeskStatusesAsync()
        {
            await Task.Delay(300);

            var _statuses = new ObservableCollection<DeskStatus>()
            {
                new DeskStatus
                {
                    Id = 1,
                    Name = "Working"
                },
                new DeskStatus
                {
                    Id = 2,
                    Name = "Broken"
                }
            };

            return _statuses;
        }
        public async Task<DeskStatus> GetDeskStatusByIdAsync(int id)
        {
            await Task.Delay(300);

            var _statuses = await GetDeskStatusesAsync();

            return _statuses.Where(e => e.Id == id).FirstOrDefault();
        }
        public async Task<bool> AddDeskStatusAsync(AddDeskStatusDto status)
        {
            await Task.Delay(2000);
            return true;
        }
        public async Task<bool> UpdateDeskStatusAsync(DeskStatus status)
        {
            await Task.Delay(300);

            return true;
        }

        #endregion

        #region Desk Methods

        public async Task<ObservableCollection<Desk>> GetDesksAsync()
        {
            await Task.Delay(500);

            var _desks = new ObservableCollection<Desk>()
            {
                new Desk()
                {
                    Id = 1,
                    Name = "Desk #1",
                    RoomId = 1,
                    RoomName = "Room #1",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 2,
                    Name = "Desk #2",
                    RoomId = 1,
                    RoomName = "Room #1",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 3,
                    Name = "Desk #3",
                    RoomId = 1,
                    RoomName = "Room #1",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 4,
                    Name = "Desk #4",
                    RoomId = 1,
                    RoomName = "Room #1",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 5,
                    Name = "Desk #5",
                    RoomId = 1,
                    RoomName = "Room #1",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 6,
                    Name = "Desk #6",
                    RoomId = 2,
                    RoomName = "Room #2",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 7,
                    Name = "Desk #7",
                    RoomId = 1,
                    RoomName = "Room #1",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 8,
                    Name = "Desk #8",
                    RoomId = 3,
                    RoomName = "Room #3",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 9,
                    Name = "Desk #9",
                    RoomId = 3,
                    RoomName = "Room #3",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 11,
                    Name = "Desk #11",
                    RoomId = 3, 
                    RoomName = "Room #3",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 35,
                    Name = "Desk #35",
                    RoomId = 1,
                    RoomName = "Room #1",
                    StatusId = 2,
                    StatusName = "Broken"
                },
                new Desk()
                {
                    Id = 36,
                    Name = "Desk #36",
                    RoomId = 2,
                    RoomName = "Room #2",
                    StatusId = 1,
                    StatusName = "Working"
                },
                new Desk()
                {
                    Id = 37,
                    Name = "Desk #37",
                    RoomId = 1,
                    RoomName = "Room #1",
                    StatusId = 2,
                    StatusName = "Broken"
                },
            };
            return _desks;
        }
        public async Task<ObservableCollection<DeskBasicInfoDto>> GetDesksBasicInfoAsync()
        {   
            await Task.Delay(1000);
            var _desks = new ObservableCollection<DeskBasicInfoDto>()
            {
                new DeskBasicInfoDto
                {
                    Id = 1,
                    Name = "Desk #1"
                },
                new DeskBasicInfoDto
                {
                    Id = 2,
                    Name = "Desk #2"
                },
                new DeskBasicInfoDto
                {
                    Id = 3,
                    Name = "Desk #3"
                },
                new DeskBasicInfoDto
                {
                    Id = 4,
                    Name = "Desk #4"
                },
                new DeskBasicInfoDto
                {
                    Id = 5,
                    Name = "Desk #5"
                },
                new DeskBasicInfoDto
                {
                    Id = 6,
                    Name = "Desk #6"
                },
                new DeskBasicInfoDto
                {
                    Id = 7,
                    Name = "Desk #7"
                }
            };

            return _desks;
        }
        public async Task<Desk> GetDeskByIdAsync(int id)
        {
            await Task.Delay(300);

            var _desks = await GetDesksAsync();

            return _desks.Where(e => e.Id == id).FirstOrDefault();
        }
        public async Task<bool> AddDeskAsync(AddDeskDto desk)
        {
            await Task.Delay(2000);
            return true;
        }
        public async Task<bool> UpdateDeskAsync(Desk desk)
        {
            await Task.Delay(1000);
            return true;
        }

        #endregion

        #region Floor Methods

        public async Task<ObservableCollection<Floor>> GetFloorsAsync()
        {
            await Task.Delay(500);

            var _floors = new ObservableCollection<Floor>()
            {
                new Floor()
                {
                    Id = 1,
                    Name = "Floor #1",
                    BuildingId = 1,
                    BuildingName = "Building #1",
                },
                new Floor()
                {
                    Id = 2,
                    Name = "Floor #2",
                    BuildingId = 1,
                    BuildingName = "Building #1",
                },
                new Floor()
                {
                    Id = 3,
                    Name = "Floor #3",
                    BuildingId = 2,
                    BuildingName = "Building #2",
                },
                new Floor()
                {
                    Id = 4,
                    Name = "Floor #4",
                    BuildingId = 3,
                    BuildingName = "Building #3",
                },
                new Floor()
                {
                    Id = 5,
                    Name = "Floor #5",
                    BuildingId = 1,
                    BuildingName = "Building #1",
                },
            };
            return _floors;
        }
        public async Task<ObservableCollection<FloorBasicInfoDto>> GetFloorBasicInfoAsync()
        {
            await Task.Delay(500);

            var _floors = new ObservableCollection<FloorBasicInfoDto>()
            {
                new FloorBasicInfoDto()
                {
                    Id = 1,
                    Name = "Floor #1",
                },
                new FloorBasicInfoDto()
                {
                    Id = 2,
                    Name = "Floor #2",
                },
                new FloorBasicInfoDto()
                {
                    Id = 3,
                    Name = "Floor #3",
                },
                new FloorBasicInfoDto()
                {
                    Id = 4,
                    Name = "Floor #4",
                },
                new FloorBasicInfoDto()
                {
                    Id = 5,
                    Name = "Floor #5",
                },
            };
            return _floors;
        }
        public async Task<Floor> GetFloorByIdAsync(int id)
        {
            await Task.Delay(300);

            var _floors = await GetFloorsAsync();

            return _floors.Where(e => e.Id == id).FirstOrDefault();
        }
        public async Task<bool> AddFloorAsync(AddFloorDto floor)
        {
            await Task.Delay(2000);
            return true;
        }
        public async Task<bool> UpdateDeskAsync(UpdateFloorDto floor)
        {
            await Task.Delay(1000);
            return true;
        }

        #endregion

        #region Room Methods

        public async Task<ObservableCollection<Room>> GetRoomsAsync()
        {
            await Task.Delay(500);

            var _rooms = new ObservableCollection<Room>()
            {
                new Room()
                {
                    Id = 1,
                    Name = "Room #1",
                    FloorId = 1,
                    FloorName = "Floor #1"
                },
                new Room()
                {
                    Id = 2,
                    Name = "Room #2",
                    FloorId = 1,
                    FloorName = "Floor #1"
                },
                new Room()
                {
                    Id = 3,
                    Name = "Room #3",
                    FloorId = 1,
                    FloorName = "Floor #1"
                },
                new Room()
                {
                    Id = 4,
                    Name = "Room #4",
                    FloorId = 1,
                    FloorName = "Floor #1"
                },
                new Room()
                {
                    Id = 5,
                    Name = "Room #5",
                    FloorId = 2,
                    FloorName = "Floor #2"
                },
                new Room()
                {
                    Id = 6,
                    Name = "Room #6",
                    FloorId = 2,
                    FloorName = "Floor #2"
                },

            };
            return _rooms;
        }
        public async Task<ObservableCollection<RoomBasicInfoDto>> GetRoomsBasicInfoAsync()
        {
            await Task.Delay(300);

            var _rooms = new ObservableCollection<RoomBasicInfoDto>()
            {
                new RoomBasicInfoDto
                {
                    Id = 1,
                    Name = "Room #1"
                },
                new RoomBasicInfoDto
                {
                    Id = 2,
                    Name = "Room #2"
                },
                new RoomBasicInfoDto
                {
                    Id = 3,
                    Name = "Room #3"
                },
                new RoomBasicInfoDto
                {
                    Id = 4,
                    Name = "Room #4"
                },
                new RoomBasicInfoDto
                {
                    Id = 5,
                    Name = "Room #5"
                },
                new RoomBasicInfoDto
                {
                    Id = 6,
                    Name = "Room #6"
                }
            };

            return _rooms;
        }
        public async Task<Room> GetRoomByIdAsync(int id)
        {
            await Task.Delay(300);

            var _rooms = await GetRoomsAsync();

            return _rooms.Where(e => e.Id == id).FirstOrDefault();
        }
        public async Task<bool> AddRoomAsync(AddRoomDto room)
        {
            await Task.Delay(2000);
            return true;
        }

        public async Task<bool> UpdateDeskAsync(UpdateRoomDto room)
        {
            await Task.Delay(1000);
            return true;
        }

        #endregion

        #region User Methods
        public async Task<ObservableCollection<User>> GetUsersAsync()
        {
            await Task.Delay(500);

            var _users = new ObservableCollection<User>()
            {
                new User()
                {
                    Id = 1,
                    FirstName = "fn #1",
                    LastName = "ln #1",
                    Login = "Login #1",
                    RoleId = Role.User,
                    TeamId = 1
                },
                new User()
                {
                    Id = 2,
                    FirstName = "fn #2",
                    LastName = "ln #2",
                    Login = "Login #2",
                    RoleId = Role.User,
                    TeamId = 1
                },
                new User()
                {
                    Id = 3,
                    FirstName = "fn #3",
                    LastName = "ln #3",
                    Login = "Login #3",
                    RoleId = Role.User,
                    TeamId = 1
                },
                new User()
                {
                    Id = 4,
                    FirstName = "fn #4",
                    LastName = "ln #4",
                    Login = "Login #4",
                    RoleId = Role.User,
                    TeamId = 2
                },
                new User()
                {
                    Id = 5,
                    FirstName = "fn #5",
                    LastName = "ln #5",
                    Login = "Login #5",
                    RoleId = Role.User,
                    TeamId = 2
                },

            };
            return _users;
        }
        public async Task<ObservableCollection<UserBasicInfoDto>> GetUsersBasicInfoAsync()
        {
            await Task.Delay(1000);
            var _users = new ObservableCollection<UserBasicInfoDto>()
            {
                new UserBasicInfoDto
                {
                    Id = 1,
                    Name = "User #1"
                },
                new UserBasicInfoDto
                {
                    Id = 2,
                    Name = "User #2"
                },
                new UserBasicInfoDto
                {
                    Id = 3,
                    Name = "User #3"
                },
                new UserBasicInfoDto
                {
                    Id = 4,
                    Name = "User #4"
                },

            };

            return _users;
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            await Task.Delay(300);

            var _users = await GetUsersAsync();

            return _users.Where(e => e.Id == id).FirstOrDefault();
        }
        public async Task<bool> AddUserAsync(AddUserDto user)
        {
            await Task.Delay(2000);
            return true;
        }
        public async Task<bool> UpdateUserAsync(UpdateUserDto user)
        {
            await Task.Delay(1000);
            return true;
        }

        #endregion

        #region Team Methods

        public async Task<ObservableCollection<Team>> GetTeamsAsync()
        {
            await Task.Delay(1000);
            var _teams = new ObservableCollection<Team>()
            {
                new Team
                {
                    Id = 1,
                    Name = "Team #1"
                },
                new Team
                {
                    Id = 2,
                    Name = "Team #2"
                },
                new Team
                {
                    Id = 3,
                    Name = "Team #3"
                },
                new Team
                {
                    Id = 4,
                    Name = "Team #4"
                },

            };

            return _teams;
        }
        public async Task<Team> GetTeamById(int id)
        {
            await Task.Delay(300);

            var _teams = await GetTeamsAsync();

            return _teams.Where(e => e.Id == id).FirstOrDefault();
        }
        public async Task<bool> AddTeamAsync(AddTeamDto team)
        {
            await Task.Delay(2000);
            return true;
        }
        public async Task<bool> UpdateTeam(Team team)
        {
            await Task.Delay(300);

            return true;
        }

        #endregion

        public async Task<bool> DeleteEntity(int id, EntityType type)
        {
            switch (type)
            {   
                case EntityType.Building:
                case EntityType.Desk:
                case EntityType.DeskStatus:
                case EntityType.Floor:
                case EntityType.Room:
                case EntityType.User:
                    return true;

                case EntityType.Unknown:
                    return false;

                default: return false;
            }
        }
    }
}
