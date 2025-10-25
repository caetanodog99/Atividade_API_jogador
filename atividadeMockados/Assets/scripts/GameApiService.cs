using UnityEngine;

public class GameApiService
{
    private readonly HttpClient httpClient;
    private const string BASE_URL = "https://68f971c1ef8b2e621e7c15fa.mockapi.io";
    public GameApiService()
    {
        httpClient = new HttpClient();
    }

    public async Task<Jogador[]>
 GetTodosJogadores()
    {
        try
        {
            string url =
            $"{BASE_URL}/Jogador";
            Debug.Log($"GET: {url}");
            HttpResponseMessage response
            = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string json = await
            response.Content.ReadAsStringAsync();
            Debug.Log($"Resposta recebida:{ json.Substring(0, Math.Min(200,json.Length))} ...");


        string wrappedJson = $"{{\"jogadores\":{json}}}";
            JogadorArray jogadorArray = JsonUtility.FromJson<JogadorArray>(wrappedJson);
            return jogadorArray.jogadores;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Erro ao buscar jogadores: { ex.Message} ");
        return new Jogador[0];
        }
    }

}
