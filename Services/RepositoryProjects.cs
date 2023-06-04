using portafolio.Models;
namespace portafolio.Services {

	public interface IRepositoryProjects {
		List<ProjectViewModel> GetProjects();
	}

public class RepositoryProjects: IRepositoryProjects {

		public List<ProjectViewModel> GetProjects() {
		return new List<ProjectViewModel>() {
			new ProjectViewModel() {
				Title = "Fusus",
				Description = "Dashboard do on Angular",
				Link = "https://amazon.com",
				ImgUrl= "/images/angular-dashboard.png",
			},
			new ProjectViewModel() {
				Title = "Redcon1",
				Description = "E-comerce with Nextjs",
				Link = "https://next.com",
				ImgUrl= "/images/e-comerce.jpeg",
			},
			new ProjectViewModel() {
				Title = "Dahsboard Hosting",
				Description = "Chat App",
				Link = "https://react.dev/",
				ImgUrl= "/images/chat-app.png",
			},
			new ProjectViewModel() {
				Title = "Am Global Group",
				Description = "Multi theme and plugin for wordpress",
				Link = "https://wordpress.org",
				ImgUrl= "/images/best-wordpress-themes-1.jpg",
			}
		};
	}
}
}