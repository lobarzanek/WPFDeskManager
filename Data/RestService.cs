using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Data;
using WPFDeskManager.Models;
using WPFDeskManager.Models.DTO;
using WPFDeskManager.Utilities;
using WPFDeskManager.Views;

namespace WPFDeskManager.Data
{
    public class RestService
    {
        private const string _apiUrl = "https://localhost:7115/api";
        private const string _brandEndpoint = "Brand";
        private const string _buildingEndpoint = "Building";
        private const string _deskEndpoint = "Desk";
        private const string _floorEndpoint = "Floor";
        private const string _itemEndpoint = "Item";
        private const string _roomEndpoint = "Room";
        private const string _teamEndpoint = "Team";
        private const string _userEndpoint = "User";
        private readonly HttpClient _httpClient;

        public RestService()
        {
            _httpClient= new HttpClient();
        }

        #region Item Methods

        public async Task<ObservableCollection<Item>> GetItemsAsync()
        {
            return await GetEntityCollectionAsync(_itemEndpoint, JsonConvert.DeserializeObject<ObservableCollection<Item>>);
        }
        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await GetEntityByIdAsync(_itemEndpoint, id, JsonConvert.DeserializeObject<Item>);
        }
        public async Task<bool> AddItemAsync(AddItemDto addItemDto)
        {
            return await AddEntityAsync(_itemEndpoint, addItemDto);
        }
        public async Task<bool> UpdateItemAsync(UpdateItemDto updateItemDto)
        {
            return await UpdateEntityAsync(_itemEndpoint, updateItemDto);
        }

        #endregion

        #region Building Methods

        public async Task<ObservableCollection<Building>> GetBuildingsAsync()
        {
            return await GetEntityCollectionAsync(_buildingEndpoint, JsonConvert.DeserializeObject<ObservableCollection<Building>>);
        }
        public async Task<Building> GetBuildingByIdAsync(int id)
        {
            return await GetEntityByIdAsync(_buildingEndpoint, id, JsonConvert.DeserializeObject<Building>);
        }
        public async Task<bool> AddBuildingAsync(AddBuildingDto building)
        {
            return await AddEntityAsync(_buildingEndpoint, building);
        }
        public async Task<bool> UpdateBuildingAsync(Building building)
        {
            return await UpdateEntityAsync(_buildingEndpoint, building);
        }

        #endregion

        #region Brand Methods

        public async Task<ObservableCollection<Brand>> GetBrandsAsync()
        {
            return await GetEntityCollectionAsync(_brandEndpoint, JsonConvert.DeserializeObject<ObservableCollection<Brand>>);
        }
        public async Task<Brand> GetBrandByIdAsync(int id)
        {
            return await GetEntityByIdAsync(_brandEndpoint, id, JsonConvert.DeserializeObject<Brand>);
        }
        public async Task<bool> AddBrandAsync(AddBrandDto brand)
        {
            return await AddEntityAsync(_brandEndpoint, brand);
        }
        public async Task<bool> UpdateBrandAsync(Brand brand)
        {
            return await UpdateEntityAsync(_brandEndpoint, brand);
        }

        #endregion

        #region Desk Methods

        public async Task<ObservableCollection<Desk>> GetDesksAsync()
        {
            return await GetEntityCollectionAsync(_deskEndpoint, JsonConvert.DeserializeObject<ObservableCollection<Desk>>);
        }
        public async Task<ObservableCollection<DeskBasicInfoDto>> GetDesksBasicInfoAsync()
        {
            return await GetEntityCollectionAsync($"{_deskEndpoint}/basic", JsonConvert.DeserializeObject<ObservableCollection<DeskBasicInfoDto>>);
        }
        public async Task<Desk> GetDeskByIdAsync(int id)
        {
            return await GetEntityByIdAsync(_deskEndpoint, id, JsonConvert.DeserializeObject<Desk>);
        }
        public async Task<bool> AddDeskAsync(AddDeskDto desk)
        {
            return await AddEntityAsync(_deskEndpoint, desk);
        }
        public async Task<bool> UpdateDeskAsync(UpdateDeskDto desk)
        {
            return await UpdateEntityAsync(_deskEndpoint, desk);
        }

        #endregion

        #region Floor Methods

        public async Task<ObservableCollection<Floor>> GetFloorsAsync()
        {
            return await GetEntityCollectionAsync(_floorEndpoint, JsonConvert.DeserializeObject<ObservableCollection<Floor>>);
        }
        public async Task<ObservableCollection<FloorBasicInfoDto>> GetFloorBasicInfoAsync()
        {
            return await GetEntityCollectionAsync($"{_floorEndpoint}/basic", JsonConvert.DeserializeObject<ObservableCollection<FloorBasicInfoDto>>);

        }
        public async Task<Floor> GetFloorByIdAsync(int id)
        {
            return await GetEntityByIdAsync(_floorEndpoint, id, JsonConvert.DeserializeObject<Floor>);
        }
        public async Task<bool> AddFloorAsync(AddFloorDto floor)
        {
            return await AddEntityAsync(_floorEndpoint, floor);
        }
        public async Task<bool> UpdateFloorAsync(UpdateFloorDto floor)
        {
            return await UpdateEntityAsync(_floorEndpoint, floor);
        }

        #endregion

        #region Room Methods

        public async Task<ObservableCollection<Room>> GetRoomsAsync()
        {
            return await GetEntityCollectionAsync(_roomEndpoint, JsonConvert.DeserializeObject<ObservableCollection<Room>>);
        }
        public async Task<ObservableCollection<RoomBasicInfoDto>> GetRoomsBasicInfoAsync()
        {
            return await GetEntityCollectionAsync($"{_roomEndpoint}/basic", JsonConvert.DeserializeObject<ObservableCollection<RoomBasicInfoDto>>);
        }
        public async Task<Room> GetRoomByIdAsync(int id)
        {
            return await GetEntityByIdAsync(_roomEndpoint, id, JsonConvert.DeserializeObject<Room>);
        }
        public async Task<bool> AddRoomAsync(AddRoomDto room)
        {
            return await AddEntityAsync(_roomEndpoint, room);
        }
        public async Task<bool> UpdateRoomAsync(UpdateRoomDto room)
        {
            return await UpdateEntityAsync(_roomEndpoint, room);
        }

        #endregion

        #region User Methods
        public async Task<ObservableCollection<User>> GetUsersAsync()
        {
            return await GetEntityCollectionAsync(_userEndpoint, JsonConvert.DeserializeObject<ObservableCollection<User>>);
        }
        public async Task<ObservableCollection<UserBasicInfoDto>> GetUsersBasicInfoAsync()
        {
            return await GetEntityCollectionAsync($"{_userEndpoint}/basic", JsonConvert.DeserializeObject<ObservableCollection<UserBasicInfoDto>>);
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await GetEntityByIdAsync(_userEndpoint, id, JsonConvert.DeserializeObject<User>);
        }
        public async Task<bool> AddUserAsync(AddUserDto user)
        {
            return await AddEntityAsync(_userEndpoint, user);
        }
        public async Task<bool> UpdateUserAsync(UpdateUserDto user)
        {
            return await UpdateEntityAsync(_userEndpoint, user);
        }

        #endregion

        #region Team Methods

        public async Task<ObservableCollection<Team>> GetTeamsAsync()
        {
            return await GetEntityCollectionAsync(_teamEndpoint, JsonConvert.DeserializeObject<ObservableCollection<Team>>);
        }
        public async Task<Team> GetTeamByIdAsync(int id)
        {
            return await GetEntityByIdAsync(_teamEndpoint, id, JsonConvert.DeserializeObject<Team>);
        }
        public async Task<bool> AddTeamAsync(AddTeamDto team)
        {
            return await AddEntityAsync(_teamEndpoint, team);
        }
        public async Task<bool> UpdateTeamAsync(Team team)
        {
            return await UpdateEntityAsync(_teamEndpoint, team);
        }

        #endregion

        #region Delete Method

        public async Task<bool> DeleteEntity(int id, EntityType type)
        {
            string endpoint = "";
            switch (type)
            {
                case EntityType.Building:
                    endpoint = _buildingEndpoint; 
                    break;
                case EntityType.Brand:
                    endpoint = _brandEndpoint;
                    break;
                case EntityType.Desk:
                    endpoint = _deskEndpoint;
                    break;
                case EntityType.Floor:
                    endpoint = _floorEndpoint;
                    break;
                case EntityType.Room:
                    endpoint = _roomEndpoint;
                    break;
                case EntityType.User:
                    endpoint = _userEndpoint;
                    break;
                case EntityType.Item:
                    endpoint = _itemEndpoint;
                    break;
                case EntityType.Team:
                    endpoint = _teamEndpoint;
                    break;

                default: break;
            }

            if (endpoint.Length > 0) 
            {
                return await DeleteEntityAsync(endpoint, id);
            }
            return false;
        }

        #endregion

        #region Private Methods

        private async Task<IEnumerable> GetEntityCollectionAsync<IEnumerable>(string endpointName, Func<string, IEnumerable> deserialize)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiUrl}/{endpointName}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = deserialize(content);

                    return result;
                }
            }
            catch (Exception ex)
            {
                return default;
            }
            return default;
        }
        private async Task<T> GetEntityByIdAsync<T>(string endpointName, int id, Func<string, T> deserialize)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiUrl}/{endpointName}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = deserialize(content);

                    if (result is not null)
                    {
                        return result;
                    }
                }

                return default;

            }
            catch (Exception ex)
            {
                return default;
            }
        }
        private async Task<bool> AddEntityAsync<T>(string endpointName, T entity)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_apiUrl}/{endpointName}", entity);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return default;

            }
            catch (Exception ex)
            {
                return default;
            }
        }
        private async Task<bool> UpdateEntityAsync<T>(string endpointName, T entity)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_apiUrl}/{endpointName}", entity);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return default;

            }
            catch (Exception ex)
            {
                return default;
            }
        }
        private async Task<bool> DeleteEntityAsync(string endpointName, int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_apiUrl}/{endpointName}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return default;

            }
            catch (Exception ex)
            {
                return default;
            }
        }

        #endregion
    }
}
