using HealthCare.Application.DataTransferObjects.UnitType;
using HealthCare.Client.Interfaces;
using System.Net;

namespace HealthCare.Client.FrontendServices;

public class UnitTypeApiService : IUnitTypeApiService<UnitTypeDto>
{

    private readonly HttpClient _httpClient;

    public UnitTypeApiService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("HealthCareAPI");
    }

    public async Task<IEnumerable<UnitTypeDto>> GetAllAsync()
    {

        var response = await _httpClient.GetFromJsonAsync<IEnumerable<UnitTypeDto>>("api/unitTypes");
        return await Task.FromResult(response);

    }

    public async Task<UnitTypeDto> GetByIdAsync(Guid id)
    {
        var response = await _httpClient.GetFromJsonAsync<UnitTypeDto>($"api/unitTypes/{id}");
        return await Task.FromResult(response);
    }

    public async Task<UnitTypeDto> AddAsync(CreateUnitTypeDto unitTypeDto)
    {

        var response = await _httpClient.PostAsJsonAsync("api/unitTypes", unitTypeDto);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to add {unitTypeDto}");
        }

        return await response.Content.ReadFromJsonAsync<UnitTypeDto>();
    }

    public async Task<bool> UpdateAsync(UnitTypeDto unitTypeDto, Guid id)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/unitTypes/{id}", unitTypeDto);

        if (!response.IsSuccessStatusCode)
        {
            return response.StatusCode == HttpStatusCode.BadRequest;
        }

        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/unitTypes/{id}");

        if (!response.IsSuccessStatusCode)
        {
            return response.StatusCode == HttpStatusCode.BadRequest;
        }

        return await Task.FromResult(true);

    }
    }