import Foundation

class FirstPresenter: FirstPresenterOutput {
    var view: FirstPresenterInput!
    var networkService: ProtocolNetworkService!
    var posts: [Post]?
    
    required init(view: FirstPresenterInput, networkService: ProtocolNetworkService) {
        self.networkService = networkService
        self.view = view
        getComments()
    }
    
    func getComments() {
        networkService.getPosts { [weak self] (result) in
            guard let self = self else { return }
            DispatchQueue.main.async {
                switch result {
                case let .success(data):
                    self.posts = data
                    self.view.success()
                case let .failure(error):
                    self.view.failure(error: error)
                }
            }
        }
    }
}
