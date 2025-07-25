using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kairos.BlazorApp;

public class KairosDbContext(DbContextOptions<KairosDbContext> options) : IdentityDbContext(options)
{
}
