using System.Net;
using HealthCare.Application.DataTransferObjects.Product;
using HealthCare.Client.Interfaces;
using HealthCare.Domain.Entities;
using HealthCare.Domain.Interfaces;

namespace HealthCare.Client.FrontendServices;

public class ProductApiService : IProductApiService<ProductDto>
{
    private readonly HttpClient _httpClient;

    public ProductApiService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("HealthCareAPI");
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {

        var response = await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/products");
        return await Task.FromResult(response);

    }

    public async Task<ProductDto> GetByIdAsync(Guid id)
    {
        var response = await _httpClient.GetFromJsonAsync<ProductDto>($"api/products/{id}");
        return await Task.FromResult(response);
    }

    public async Task<ProductDto> AddAsync(ProductDto productDto)
    {

        var response = await _httpClient.PostAsJsonAsync<ProductDto>("api/products", productDto);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to add {productDto}");
        }

        return await response.Content.ReadFromJsonAsync<ProductDto>();
    }

    public async Task<bool> UpdateAsync(ProductDto productDto, Guid id)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/products/{id}", productDto);

        if (!response.IsSuccessStatusCode)
        {
            return response.StatusCode == HttpStatusCode.BadRequest;
        }

        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/products/{id}");

        if (!response.IsSuccessStatusCode)
        {
            return response.StatusCode == HttpStatusCode.BadRequest;
        }

        return await Task.FromResult(true);

    }

    public async Task<bool> UpdateQuantityOnProductAsync(Guid id, int changeAmount)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/products/{id}/quantity", changeAmount);

        if (!response.IsSuccessStatusCode)
        {
            return response.StatusCode == HttpStatusCode.BadRequest;
        }

        return await Task.FromResult(true);

    }
}