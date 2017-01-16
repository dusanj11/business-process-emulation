>HiringCompanyClient.proj<
	
	Directories(namespaces):
	->HiringCompanyClient.Behaviours
		-Contains class PasswordBoxAssistaint for allowing to set binding on WPF PasswordBox component

	->HiringCompanyClient.Command
		-actions that can be taken by the client himself

	->HiringCompanyClient.Model
		-models of some entities from real life

	->HiringCompanyClient.PassingConverter
		-convert data for views

	->HiringCompanyClient.View
		-GUI views

	->HiringCompanyClient.ViewModels
		-models that are required for the proper use of MVVM pattern

	->HiringCompanyClient.ViewModelInterfaces
		-Interfaces for each ViewModel class for mocking the instance of ViewModel

	->HiringCompanyClient.Windows
		-log in window + client window

	->ClientProxy.cs 
		-Representation of the same object structure that will be serialized and then passed over the wire
		 to the endpoint (the HiringCompany service).