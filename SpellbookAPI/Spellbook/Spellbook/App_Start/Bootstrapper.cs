using System.Data.Entity;
using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using Spellbook.DataContext;
using Spellbook.Models;
using Spellbook.Repositories;
using Spellbook.Services;

namespace Spellbook.App_Start
{
    public class Bootstrapper {

        public static IContainer RegisterTypes() {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            containerBuilder.RegisterType<SpellbookDbContext>().As<IDbContext>().InstancePerLifetimeScope();

            // register services
            containerBuilder.RegisterType<SpellbookService>().As<ISpellbookService>();

            // register repos
            containerBuilder.RegisterType<SpellRepository>().As<IRepository<Spell>>();
            containerBuilder.RegisterType<SpellListRepository>().As<IRepository<SpellList>>();
            containerBuilder.RegisterType<CharacterRepository>().As<IRepository<Character>>();

            return containerBuilder.Build();
        }
    }
}