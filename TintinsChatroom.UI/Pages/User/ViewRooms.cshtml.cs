using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TintinsChatroom.DTO.Database;
using TintinsChatroom.DTO.Models;

namespace TintinsChatroom.UI.Pages.User
{
    public class ViewRoomsModel : PageModel
    {
        private readonly SignInManager<ChatUserModel> signInManager;

        public ChatUserModel ChatUser { get; set; } = new ChatUserModel();
        public List<ChatUserModel> ChatUsers { get; set; } = new List<ChatUserModel>();
        public AuthDbContext Context { get; set; } = new AuthDbContext();
        public List<ChatRoomModel> RoomModels { get; set; } = new List<ChatRoomModel>();


        public ViewRoomsModel(SignInManager<ChatUserModel> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task OnGet()
        {
            RoomModels = Context.ChatRoomModels.ToList();

            ChatUser = await signInManager.UserManager.GetUserAsync(HttpContext.User);

        }
    }
}
