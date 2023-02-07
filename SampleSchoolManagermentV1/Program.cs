using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SampleSchoolManagermentV1.Datas;
using SampleSchoolManagermentV1.EmailService;
using SampleSchoolManagermentV1.Repository.Repositories.Implement;
using SampleSchoolManagermentV1.Repository.Repositories.Interfaces;
using SampleSchoolManagermentV1.Repository.UnitOfWork;
using SampleSchoolManagermentV1.Services;
using SampleSchoolManagermentV1.Services.Interfaces;
using SampleSchoolManagermentV1.Validation;
using System.IO;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// add newton

builder.Services.AddControllers().AddNewtonsoftJson(op => 
op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore) ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//ADD SWAGGER
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    option.IncludeXmlComments(xmlPath);
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                            }
                        },
            new string[]{}
        }
                });
});
//MAIL 
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailService, MailService>();
//db
builder.Services.AddDbContext<SchoolContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SimpleSchoolConnStr")));

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
//dang ki lifecircle
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ISubjectService, SubjectService>();

builder.Services.AddScoped<IMarkRepository, MarkRepository>();
builder.Services.AddScoped<IMarkService, MarkService>();

builder.Services.AddScoped<ITimeTableRepository, TimeTableRepository>();
builder.Services.AddScoped<ITimeTableService, TimeTableService>();


builder.Services.AddScoped<IFileExcelService, FileExcelService>();

// user 

//identity
builder.Services.AddIdentity<IdentityUser,IdentityRole>()
    .AddEntityFrameworkStores<SchoolContext>().AddDefaultTokenProviders();
//Add Authentication 
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(opstions =>
{
    opstions.SaveToken = true;
    opstions.RequireHttpsMetadata = false;
    opstions.TokenValidationParameters = new
    TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))

    };
});


// Add CORS
builder.Services.AddCors(p => p.AddPolicy("MyCors", build =>
{
    //build.WithOrigins("https://localhost:3000");
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


var converter = new SynchronizedConverter(new PdfTools()); 
builder.Services.AddSingleton(converter);
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCookiePolicy();

app.UseRouting();
app.UseCors("MyCors");

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
