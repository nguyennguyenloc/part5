using part5.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part5.data.DAL
{
    public class UserDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public User GetByUsername(string username)
        {
            //Get from database
            var user = context.Users
                .Where(i => i.Username == username && (i.IsDeleted == false || i.IsDeleted == null))
                .FirstOrDefault();
            return user;
        }

        public bool Update(User model)
        {
            try
            {
                //Get item user with Id from database
                var item = context.Users.Where(i => i.Id == model.Id).FirstOrDefault();

                //Set value item with value from model
                item.Username = model.Username;
                item.Address = model.Address;
                item.CreatedBy = model.CreatedBy;
                item.CreatedTime = model.CreatedTime;
                item.DateOfBirth = model.DateOfBirth;
                item.DeletedBy = model.DeletedBy;
                item.DeletedTime = model.DeletedTime;
                item.Email = model.Email;
                item.FirstName = model.FirstName;
                item.Id = model.Id;
                item.IsDeleted = model.IsDeleted;
                item.LastName = model.LastName;
                item.ModifiedBy = model.ModifiedBy;
                item.ModifiedTime = model.ModifiedTime;
                item.PasswordEncrypted = model.PasswordEncrypted;
                item.PasswordSalt = model.PasswordSalt;
                item.PhoneNumber = model.PhoneNumber;
                item.Sex = model.Sex;
            

                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(User model)
        {
            try
            {
                //Initialization empty item
                var item = new User();

                //Set value for item with value from model
                item.Username = model.Username;
                item.Username = model.Username;
                item.Address = model.Address;
                item.CreatedBy = model.CreatedBy;
                item.CreatedTime = model.CreatedTime;
                item.DateOfBirth = model.DateOfBirth;
                item.DeletedBy = model.DeletedBy;
                item.DeletedTime = model.DeletedTime;
                item.Email = model.Email;
                item.FirstName = model.FirstName;
                item.Id = model.Id;
                item.IsDeleted = model.IsDeleted;
                item.LastName = model.LastName;
                item.ModifiedBy = model.ModifiedBy;
                item.ModifiedTime = model.ModifiedTime;
                item.PasswordEncrypted = model.PasswordEncrypted;
                item.PasswordSalt = model.PasswordSalt;
                item.PhoneNumber = model.PhoneNumber;
                item.Sex = model.Sex;

                //Add item to entity
                context.Users.Add(item);
                //Save to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                //Tương tự update
                var item = context.Users.SingleOrDefault(i => i.Id == id);

                //Remove item.
                context.Users.Remove(item);

                //Change database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
