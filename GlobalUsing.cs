global using System.Collections.ObjectModel;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.Linq.Expressions;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;

global using Microsoft.IdentityModel.Tokens;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.Options;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Authentication.JwtBearer;

global using AutoMapper;

global using aspnetcore_tutorial.Persistence;
global using aspnetcore_tutorial.Core.Models;
global using aspnetcore_tutorial.Controllers.Resources;
global using aspnetcore_tutorial.Mapping;
global using aspnetcore_tutorial.Core;
global using aspnetcore_tutorial.Extensions;
global using aspnetcore_tutorial.Middlewares;