// MARK: - DataBase
var db: [(String, String)] = [("kek", "123")]

// MARK: - Username for authenticate
class User {
    let username: String
    let password: String
    let url: String // Somethin url
    init(username: String, password: String, url: String) {
        self.username = username
        self.password = password
        self.url = url
    }
}

// MARK: - ServerProtocol for Side, Proxy
protocol ServerProtocol {
    func request(user: User)
}

class ServerSide: ServerProtocol {
    func request(user: User) {
        print("Sended request \(user.url)")
    }
}

// MARK: - Proxy
class ServerProxy: ServerProtocol {
    var serverSide: ServerSide?
    
    func request(user: User) {
        guard serverSide != nil else {
            print("User don't authenticated")
            return
        }
        
        serverSide?.request(user: user)
    }
    
    func authenticate(user: User) {
        if db.contains(where: { $0.0 == user.username && $0.1 == user.password}) {
            serverSide = ServerSide()
        } else {
            print("User don't registred")
        }
    }
    
    func register(user: User) {
        if !db.contains(where: { $0.0 == user.username && $0.1 == user.password}) {
            db.append((user.username, user.password))
            print("User has registred")
        } else {
            print("User already registred")
        }
    }
}

func board() {
    print("]-------------[")
}

func main() {
    let me = User(username: "timoninas", password: "123", url: "/htrhrt/trhrtlh/tlhrhr.com")
    
    let serverSide = ServerSide()
    serverSide.request(user: me);
    board()
    let serverProxy = ServerProxy()
    serverProxy.request(user: me);
    board()
    serverProxy.authenticate(user: me)
    serverProxy.request(user: me);
    board()
    serverProxy.register(user: me)
    serverProxy.authenticate(user: me)
    serverProxy.request(user: me);
    board()
    serverProxy.register(user: me)
}

main()
