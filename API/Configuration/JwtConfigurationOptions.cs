using Infrastructure.Authentication;
using Microsoft.Extensions.Options;

namespace API.Configuration;

public class JwtConfigurationOptions : IConfigureOptions<JwtOptions>
{
    private const string Section = "Jwt";
    private readonly IConfiguration _configuration;

    public JwtConfigurationOptions(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        _configuration.GetSection(Section).Bind(options);
    }
}