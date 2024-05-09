using System.ComponentModel.DataAnnotations;

namespace Kooi.Domain.Models.Tooltips
{

    public class Tooltip
    {

        [Key]
        public System.Guid Id { get; init; }
        public Guid ContentTypeId { get; init; }
        public string Title { get; set; }
        public string Description { get; init; }
        public bool ShowProgress { get; init; }
        public string ProgressText { get; init; }
        public string NextBtnText { get; init; }
        public string PrevBtnText { get; init; }
        public string DoneBtnText { get; init; }

        public static Tooltip Create(
            string Title,
            Guid ContentTypeId,
            string Description, 
            bool ShowProgress, 
            string ProgressText, 
            string NextBtnText, 
            string PrevBtnText, 
            string DoneBtnText)
        {
            return new Tooltip
            {
                Title = Title,
                ContentTypeId = ContentTypeId,
                Description = Description,
                ShowProgress = ShowProgress,
                ProgressText = ProgressText,
                NextBtnText = NextBtnText,
                PrevBtnText = PrevBtnText,
                DoneBtnText = DoneBtnText
            };
        }

        public static Tooltip Create(
            Guid id,
            string Title,
            Guid ContenTtypeId,
            string Description,
            bool ShowProgress,
            string ProgressText,
            string NextBtnText,
            string PrevBtnText,
            string DoneBtnText)
        {
            return new Tooltip
            {
                Id = id,
                Title = Title,
                ContentTypeId = ContenTtypeId,
                Description = Description,
                ShowProgress = ShowProgress,
                ProgressText = ProgressText,
                NextBtnText = NextBtnText,
                PrevBtnText = PrevBtnText,
                DoneBtnText = DoneBtnText
            };
        }

    }
}
