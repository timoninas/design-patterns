import UIKit

protocol ProtocolNetworkService {
    func getPosts(completion: @escaping (Result<[Post]?, Error>) -> Void)
}

class NetworkService: ProtocolNetworkService {
    static let urlString = "https://jsonplaceholder.typicode.com/posts"
    
    func getPosts(completion: @escaping (Result<[Post]?, Error>) -> Void) {
        guard let url = URL(string: NetworkService.urlString) else { return }
        
        let session = URLSession.shared.dataTask(with: url) { (data, response, error) in
            if let error = error {
                completion(.failure(error))
            }
            
            do {
                let obj = try JSONDecoder().decode([Post].self, from: data!)
                completion(.success(obj))
            } catch {
                completion(.failure(error))
            }
        }
        
        session.resume()
    }
}
