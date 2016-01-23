using EventApp.DTO;
using EventApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Service
{
    public static class RestApiManager
    {

        public static async Task<Boolean> Authenticate(String userName, String password)
        {
            return await RestHelper.Instance.Authenticate(userName, password);
        }

        #region user

        public static async Task<RestResult<User>> GetUser(string login)
        {
            RestResult<UserDTO> ret = await RestHelper.Instance.GetData<UserDTO>("api/users/" + login);
            if (ret.IsSuccess)
            {
                var usr = ret.Data.ToUser();
                DataSource.DS.User = usr;
                return new RestSuccessResult<User>(usr);
            }
            else
                return new RestFailureResult<User>(ret.ErrorTitle, ret.ErrorMessage);
        }
        #endregion

        #region event
        public static async Task<Event> CreateEvent(Event evt)
        {
            RestResult<EventDTO> ret = await RestHelper.Instance.Post<EventDTO, EventDTO>("api/event", evt.ToEventDTO());
            if (ret.IsSuccess)
            {
                return new Event()
                {
                    Id = ret.Data.id,
                    Name = ret.Data.name,
                    StartDate = DateTime.Now
                };
            }
            else
                return null;
        }

        public static async Task<Event> UpdateEvent(Event evt)
        {
            RestResult<EventDTO> ret = await RestHelper.Instance.Put<EventDTO, EventDTO>("api/event", evt.ToEventDTO());
            if (ret.IsSuccess)
            {
                return new Event()
                {
                    Id = ret.Data.id,
                    Name = ret.Data.name,
                    StartDate = DateTime.Now
                };
            }
            else
                return null;
        }

        public static async Task<RestResult<Boolean>> GetOwnedEvents()
        {
            RestResult<List<EventDTO>> ret = await RestHelper.Instance.GetData<List<EventDTO>>("api/events/owned");
            if (ret.IsSuccess)
            {
                DataSource.DS.Events.Clear();
                DataSource.DS.Events.AddRange(ret.Data.Select(dto => dto.ToEvent()));
                return new RestSuccessResult<Boolean>(true);
            }
            else
                return new RestFailureResult<Boolean>(ret.ErrorTitle, ret.ErrorMessage);
        }

        public static async Task<RestResult<Event>> GetEvent(int id)
        {
            RestResult<EventDTO> ret = await RestHelper.Instance.GetData<EventDTO>("api/events/" + id);
            if (ret.IsSuccess)
            {
                var evt = ret.Data.ToEvent();
                DataSource.DS.Events.RemoveAll(e => e.Id == id);
                DataSource.DS.Events.Add(evt);
                return new RestSuccessResult<Event>(evt);
            }
            else
                return new RestFailureResult<Event>(ret.ErrorTitle, ret.ErrorMessage);
        }
        #endregion

        #region picture
        public static async Task<RestResult<Picture>> GetPicture(int eventId, int number)
        {
            RestResult<PictureDTO> ret = await RestHelper.Instance.GetData<PictureDTO>("api/pictures/detail/" + eventId + "/" + number);
            if (ret.IsSuccess)
            {
                return new RestSuccessResult<Picture>(ret.Data.ToPicture());
            }
            else
                return new RestFailureResult<Picture>(ret.ErrorTitle, ret.ErrorMessage);
        }

        public static async Task<Boolean> LoadEventPictures(Event evt)
        {
            evt.Pictures.Clear();
            for (var i = 1; i <= evt.PictureNb; i++)
            {
                RestResult<Picture> retPic = await RestApiManager.GetPicture(evt.Id, i);
                Picture pic = null;
                if (retPic.IsSuccess)
                {
                    pic = retPic.Data;
                    pic.Number = i;
                }
                else {
                    pic = new Picture()
                    {
                        Id = i,
                        Eventt = evt,
                        Number = i,
                        FileName = "ERREUR " + i
                    };
                }
                evt.Pictures.Add(pic);
            }
            return true;
        }

        public static async Task<Boolean> TopPicture(int pictureId)
        {
            RestResult<PictureTopDTO> ret = await RestHelper.Instance.Post<PictureTopCreateDTO, PictureTopDTO>("api/pictureTops", new PictureTopCreateDTO()
            {
                pictureId = pictureId
            });
            if (ret.IsSuccess)
            {
                return true;
            }
            else
                return false;
        }

        public static async Task<Boolean> CommentPicture(int pictureId, string comment)
        {
            RestResult<PictureCommentDTO> ret = await RestHelper.Instance.Post<PictureCommentCreateDTO, PictureCommentDTO>("api/pictureTops", new PictureCommentCreateDTO()
            {
                pictureId = pictureId,
                comment = comment
            });
            if (ret.IsSuccess)
            {
                return true;
            }
            else
                return false;
        }

        //public static async Task<RestResult<Picture>> GetPictureTop(int eventId, int number)
        //{
        //    RestResult<PictureDTO> ret = await RestHelper.Instance.GetData<PictureDTO>("api/pictures/detail/" + eventId + "/" + number);
        //    if (ret.IsSuccess)
        //    {
        //        return new RestSuccessResult<Picture>(ret.Data.ToPicture());
        //    }
        //    else
        //        return new RestFailureResult<Picture>(ret.ErrorTitle, ret.ErrorMessage);
        //}
        #endregion
    }
}
