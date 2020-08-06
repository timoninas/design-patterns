protocol Composite {
    var name: String { get }
    func addComponent(_ c: Composite)
    func showComponents()
}

class Folder: Composite {
    var name: String
    private var contents: [Composite]
    
    init(name: String) {
        self.name = name
        self.contents = []
    }
    
    func addComponent(_ c: Composite) {
        contents.append(c)
    }
    
    func showComponents() {
        print("name -> (\(self.name))")
        for value in contents {
            value.showComponents()
        }
    }
}

class File: Composite {
    var name: String
    
    init(name: String) {
        self.name = name
    }
    
    func addComponent(_ c: Composite) {
        fatalError()
    }
    
    func showComponents() {
        print("name -> (\(self.name))")
    }
}

func main() {
    let folderMain = Folder(name: "Main")
    
    let folder1 = Folder(name: "Folder1")
    let folder2 = Folder(name: "Folder2")
    
    let file1 = Folder(name: "File1")
    let file2 = Folder(name: "File2")
    
    folder1.addComponent(folder2)
    folder1.addComponent(file1)
    folder1.addComponent(file2)
    
    folderMain.addComponent(folder1)
    folderMain.addComponent(file2)
    
    
    folderMain.showComponents()
}

main()
