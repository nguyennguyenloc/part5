using part5.data.DAL;
using part5.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part5.service
{
    public class PostService
    {
        private PostDAL postDAL = new PostDAL();

        public bool Create(Post model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var create = postDAL.Create(model);
                return create;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Post model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }
                var update = postDAL.Update(model);
                return update;
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
                var update = postDAL.Delete(id);
                return update;
            }
            catch
            {
                return false;
            }
        }

        public Post GetById(long id)
        {
            return postDAL.GetById(id);
        }

        public Post GetByAlias(string alias)
        {
            if (string.IsNullOrEmpty(alias))
            {
                return null;
            }
            return postDAL.GetByAlias(alias);
        }

        public IEnumerable<Post> GetList()
        {
            return postDAL.GetList();
        }
    }
}
