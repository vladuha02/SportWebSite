using System.Linq;

namespace SportWebSite.Data.Repository
{
    public static class ModelModifyExtension
    {
        public static void ModelModify<T, K>(this T entityToUpdate, K entity)
        {
            //var modelToUpdatePropertiesInfo = Type.GetType(entityToUpdate.GetType().Name).GetProperties();
            var modelToUpdatePropertiesInfo = entityToUpdate.GetType().GetProperties();

            var modelPropertiesInfo = entity.GetType().GetProperties();

            foreach (var propModel in modelToUpdatePropertiesInfo)
            {
                var prop = modelPropertiesInfo.FirstOrDefault(m => m.Name == propModel.Name);

                if (prop != null && propModel.PropertyType == prop.PropertyType)
                {
                    //propModel.SetValue(propModel, prop., null);
                }
            }
        }

        //public static void ModelModify(this PlayerServiceModel servicePlayer, Player player)
        //{
        //    PropertyInfo prop = servicePlayer.GetType().GetProperty("name", BindingFlags.Public | BindingFlags.Instance);
        //    if (null != prop && prop.CanWrite)
        //    {
        //        prop.SetValue(servicePlayer, player.Name, null);
        //    }

        //    prop = player.GetType().GetProperty("position", BindingFlags.Public | BindingFlags.Instance);
        //    if (null != prop && prop.CanWrite)
        //    {
        //        prop.SetValue(servicePlayer, player.Position, null);
        //    }

        //    prop = player.GetType().GetProperty("dateOfBirth", BindingFlags.Public | BindingFlags.Instance);
        //    if (null != prop && prop.CanWrite)
        //    {
        //        prop.SetValue(servicePlayer, player.DateOfBirth, null);
        //    }

        //    prop = player.GetType().GetProperty("countryOfBirth", BindingFlags.Public | BindingFlags.Instance);
        //    if (null != prop && prop.CanWrite)
        //    {
        //        prop.SetValue(servicePlayer, player.CountryOfBirth, null);
        //    }

        //    prop = player.GetType().GetProperty("nationality", BindingFlags.Public | BindingFlags.Instance);
        //    if (null != prop && prop.CanWrite)
        //    {
        //        prop.SetValue(servicePlayer, player.Nationality, null);
        //    }

        //    prop = player.GetType().GetProperty("role", BindingFlags.Public | BindingFlags.Instance);
        //    if (null != prop && prop.CanWrite)
        //    {
        //        prop.SetValue(servicePlayer, player.Role, null);
        //    }
        //}

        //public static void ModelModify(this User user, UserServiceModel serviceUser)
        //{
        //    PropertyInfo prop = user.GetType().GetProperty("BirthDate", BindingFlags.Public | BindingFlags.Instance);
        //    if (null != prop && prop.CanWrite)
        //    {
        //        prop.SetValue(user, serviceUser.BirthDate, null);
        //    }

        //    prop = user.GetType().GetProperty("Email", BindingFlags.Public | BindingFlags.Instance);
        //    if (null != prop && prop.CanWrite)
        //    {
        //        prop.SetValue(user, serviceUser.Email, null);
        //    }

        //    prop = user.GetType().GetProperty("Gender", BindingFlags.Public | BindingFlags.Instance);
        //    if (null != prop && prop.CanWrite)
        //    {
        //        prop.SetValue(user, serviceUser.Gender, null);
        //    }

        //    prop = user.GetType().GetProperty("Location", BindingFlags.Public | BindingFlags.Instance);
        //    if (null != prop && prop.CanWrite)
        //    {
        //        prop.SetValue(user, serviceUser.Location, null);
        //    }

        //    prop = user.GetType().GetProperty("Login", BindingFlags.Public | BindingFlags.Instance);
        //    if (null != prop && prop.CanWrite)
        //    {
        //        prop.SetValue(user, serviceUser.Login, null);
        //    }
        //    prop = user.GetType().GetProperty("Name", BindingFlags.Public | BindingFlags.Instance);
        //    if (null != prop && prop.CanWrite)
        //    {
        //        prop.SetValue(user, serviceUser.Name, null);
        //    }
        //    prop = user.GetType().GetProperty("Role", BindingFlags.Public | BindingFlags.Instance);
        //    if (null != prop && prop.CanWrite)
        //    {
        //        prop.SetValue(user, serviceUser.Role, null);
        //    }
        //}

        //public static void ModelModify(this Team team, TeamServiceModel serviceTeam)
        //{
        //    PropertyInfo prop = team.GetType().GetProperty("TeamName", BindingFlags.Public | BindingFlags.Instance);
        //    if (null != prop && prop.CanWrite)
        //    {
        //        prop.SetValue(team, serviceTeam.TeamName, null);
        //    }

        //    prop = team.GetType().GetProperty("SportType", BindingFlags.Public | BindingFlags.Instance);
        //    if (null != prop && prop.CanWrite)
        //    {
        //        prop.SetValue(team, serviceTeam.SportType, null);
        //    }

        //    prop = team.GetType().GetProperty("Players", BindingFlags.Public | BindingFlags.Instance);
        //    if (null != prop && prop.CanWrite)
        //    {
        //        prop.SetValue(team, serviceTeam.Players, null);
        //    }
        //}

        //public static void ModelModify(this TeamServiceModel serviceTeam, Team team)
        //{
        //    PropertyInfo prop = serviceTeam.GetType().GetProperty("TeamName", BindingFlags.Public | BindingFlags.Instance);
        //    if (null != prop && prop.CanWrite)
        //    {
        //        prop.SetValue(serviceTeam, team.TeamName, null);
        //    }

        //    prop = team.GetType().GetProperty("SportType", BindingFlags.Public | BindingFlags.Instance);
        //    if (null != prop && prop.CanWrite)
        //    {
        //        prop.SetValue(serviceTeam, team.SportType, null);
        //    }

        //    prop = team.GetType().GetProperty("Players", BindingFlags.Public | BindingFlags.Instance);
        //    if (null != prop && prop.CanWrite)
        //    {
        //        prop.SetValue(serviceTeam, team.Players, null);
        //    }
        //}
    }
}