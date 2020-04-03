class Document {
    
    // Шаблонный метод
    final func templateMethod() {
        addDocument()
        encryptDocument()
        openDocument()
        readDocument()
    }
    
    func addDocument() {
        preconditionFailure()
    }
    
    func openDocument() {
        print("open Document")
    }
    
    func encryptDocument() {
        preconditionFailure()
    }
    
    func readDocument() {
        preconditionFailure()
    }
}

class PDFDocument: Document {
    override func addDocument() {
        print("add PDF document")
    }
    
    override func encryptDocument() {
    }
    
    override func readDocument() {
        print("read PDF document")
    }
}

class EncryptedDocument: Document {
    override func addDocument() {
        print("add crypted document")
    }
    
    override func encryptDocument() {
        print("encrypt document")
    }
    
    override func openDocument() {
        print("open encrypted document")
    }
    
    override func readDocument() {
        print("read encrypted document")
    }
}

func board() {
    print("\n|----------------------------------|\n")
}

func main() {
    let doc1 = PDFDocument()
    doc1.templateMethod()
    
    board()
    
    let doc2 = EncryptedDocument()
    doc2.templateMethod()
}

main()
