using EventApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Model
{
    public static class Converter
    {
        public static User ToUser(this UserDTO dto)
        {
            return new User()
            {
                Id = dto.id,
                Email = dto.email,
                Activated = dto.activated,
                CreatedDate = dto.createdDate,
                FirstName = dto.firstName,
                LangKey = dto.langKey,
                LastModifiedDate = dto.lastModifiedDate,
                LastName = dto.lastName,
                Login = dto.login
            };
        }

        public static Event ToEvent(this EventDTO dto)
        {
            return new Event()
            {
                Id = dto.id,
                Name = dto.name,
                StartDate = dto.startDate,
                EndDate = dto.endDate,
                Location = dto.location,
                Description = dto.description,
                PictureNb = dto.pictureNb,
                AllowedStorage = dto.allowedStorage,
                UsedStorage = dto.usedStorage,
                ActivationEndDate = dto.activationEndDate,
                ActivationStartDate = dto.activationStartDate,
                //EventState
                //EventType
                //Owner
                //Members
            };
        }

        public static EventDTO ToEventDTO(this Event o)
        {
            return new EventDTO()
            {
                id = o.Id,
                name = o.Name,
                startDate = o.StartDate
            };
        }

        public static Picture ToPicture(this PictureDTO dto)
        {
            return new Picture()
            {
                Id = dto.id,
                Eventt = new Event()
                {
                    Id = dto.eventId,
                    Name = dto.eventName
                },
                FileName = dto.fileName,
                Latitude = dto.latitude,
                Longitude = dto.longitude,
                Owner = new User()
                {
                    Id = dto.ownerId,
                    Email = dto.ownerEmail
                },
                PictureDate = dto.pictureDate,
                Size = dto.size,
            };
        }

        public static PictureDTO ToPictureDTO(this Picture o)
        {
            return new PictureDTO()
            {
                id = o.Id,
                eventId = o.Eventt.Id,
                fileName = o.FileName,
                latitude = o.Latitude,
                longitude = o.Longitude,
                ownerId = o.Owner.Id,
                pictureDate = o.PictureDate,
                size = o.Size
            };
        }

    }
}
