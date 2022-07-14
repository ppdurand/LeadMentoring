using petshop.model;

Clinic clinic = new Clinic();

ClinicRegister();

void Menu(){
    Console.Clear();

    char choice;
    Console.WriteLine($"*********CLÍNICA {clinic.Name}*********");
    Console.WriteLine();

    Console.WriteLine("1 - Cadastrar Animal");
    Console.WriteLine("2 - Alterar Idade de um Animal");
    Console.WriteLine("3 - Calcular Média da Idade dos Animais Machos");
    Console.WriteLine("4 - Calcular Média da Idade dos Animais Fêmeas");
    Console.WriteLine("5 - Calcular Média Geral da Idade de todos os Animais");
    Console.WriteLine("6 - Alterar Endereço da Clínica");
    Console.WriteLine("7 - Detalhes da Clínica");
    Console.WriteLine("8 - Lista dos Animais");
    Console.WriteLine("X - Sair do Programa");

    Console.SetBufferSize();
    Console.Write("Opção desejada: ");
    choice = Convert.ToChar(Console.ReadLine());

    switch(choice){
        case '1':
            AnimalRegister();
            break;
        case '2':
            ChangeAge(); 
            break;
        case '3':
            MaleAgeAverage();
            break;
        case '4':
            FemaleAgeAverage();
            break;
        case '5':
            AgeAverage();
            break;
        case '6':
            ChangeAddress();
            break;
        case '7':
            ClinicDetails();
            break;
        case '8':
            ShowListAnimal();
            break;
        case 'x':
            Console.WriteLine("Saindo do Programa");
            break;
        default:
            Console.WriteLine("Comando não reconhecido");
            GetBackToMenu();
            break;
    }
}

void ClinicRegister(){
    Console.Clear();

    Console.WriteLine("=-=-=-CADASTRO DE CLÍNICA=-=-=-");
    Console.Write("Nome da Clínica: ");
    clinic.Name = Console.ReadLine();
    Console.Write("Endereço da Clínica: ");
    clinic.Address = Console.ReadLine();

    if(clinic.Name == ""){
        Console.WriteLine();
        Console.WriteLine("O nome da clínica é obrigatório para o cadastro");

        Console.WriteLine("Aperte qualquer tecla para tentar novamente");
        Console.ReadKey();
        ClinicRegister();
    }
    Menu();
}

void AnimalRegister(){
    Console.Clear();

    Console.WriteLine("##### REGISTRAR ANIMAL #####");
    Console.WriteLine();

    string species, name, ageStr;
    int age, animalNumber;
    char sex;

    Console.Write("Espécie do Animal: ");
    species = Console.ReadLine();
    Console.Write("Nome do Animal: ");
    name = Console.ReadLine();

    Console.Write("Idade do Animal: ");
    ageStr = Console.ReadLine();
    Int32.TryParse(ageStr, out age);

    Console.Write("Sexo do Animal(M/F): ");
    sex = Convert.ToChar(Console.ReadLine());

    if(name == ""){
        Console.WriteLine("O nome e o sexo são obrigatórios para o cadastro");
        Console.WriteLine("Aperte qualquer tecla para tentar novamente");
        Console.ReadKey();

        AnimalRegister();
    }

    int count = 1001;
    foreach(var animal in clinic.AnimalList){
        ++count;
    }
    animalNumber = count;

    if(sex == 'M' || sex == 'F'){
        clinic.AnimalList.Add(new Animal(species, name, age, sex, animalNumber));
        Console.WriteLine();

        Console.WriteLine("Animal Cadastrado");
        Console.WriteLine($"O número do seu animal é {count}");
        GetBackToMenu();
    }else{
        Console.WriteLine("Sexo inválido, coloque 'M' ou 'F' em MAIÚSCULO");
        Console.WriteLine("Digite qualquer tecla para tentar novamente");
        Console.ReadKey();
        AnimalRegister();
    }
}

void ChangeAge(){ 
    Console.Clear();
    Console.WriteLine("0000000 ALTERAÇÃO DE IDADE 0000000");
    Console.WriteLine();

    int count = 0;
    //if(clinic.AnimalList.Count > 0);
    Console.Write("Informe o número do seu animal: ");
    string checkAnimalNumberSTR = Console.ReadLine();
    Int32.TryParse(checkAnimalNumberSTR, out int checkAnimalNumber);

    foreach(var animal in clinic.AnimalList){
        count += 1;
        if (animal.AnimalNumber == checkAnimalNumber){
            Console.WriteLine("Animal encontrado");
            Console.WriteLine($"Nome: {animal.Name}");
            Console.WriteLine($"Idade: {animal.Age}");
            Console.WriteLine();

            Console.Write("Informe a nova idade: ");
            string newAgeSTR = Console.ReadLine();
            Int32.TryParse(newAgeSTR, out int newAge);
            animal.Age = newAge;

            Console.WriteLine($"Idade alterada com sucesso! Agora seu pet tem {animal.Age} anos");
            GetBackToMenu();
        }
    }
    if (count == 0){
        Console.WriteLine();
        Console.WriteLine("Sem registros de animais");
        GetBackToMenu();
    }
    Console.WriteLine("Animal não encontrado");
    Console.WriteLine("Aperte qualquer tecla para tentar novamente");
    Console.ReadKey();

    ChangeAge();
}

void AgeAverage(){
    Console.Clear();
    Console.WriteLine("***** MÉDIA DE IDADE DOS ANIMAIS *****");
    Console.WriteLine();

    int count = 0;
    double average, sum = 0;
    foreach(var animal in clinic.AnimalList){
        count++;
        sum += animal.Age;
    }
    if(count == 0){
        Console.WriteLine("Sem Registro de Animais");
        GetBackToMenu();
    }
    average = sum / clinic.AnimalList.Count();

    Console.WriteLine($"MÉDIA: {average.ToString("F")} anos");

    GetBackToMenu();
}

void MaleAgeAverage(){
    Console.Clear();
    Console.WriteLine("***** MÉDIA DOS ANIMAIS MACHOS *****");

    int count = 0;
    double average, maleSum = 0;
    foreach(var animal in clinic.AnimalList){
        if(animal.Sex == 'M'){
            maleSum += animal.Age;
            count++;
        }
    }
    if(count == 0){
        Console.WriteLine();
        Console.WriteLine("Sem Registros de Animais Machos");
        GetBackToMenu();
    }
    average = maleSum / count;
    Console.WriteLine($"MÉDIA: {average.ToString("F")} anos");

    GetBackToMenu();
}

void FemaleAgeAverage(){
    Console.Clear();
    Console.WriteLine("***** MÉDIA DOS ANIMAIS FÊMEAS *****");

    int count = 0;
    double average, femaleSum = 0;
    foreach(var animal in clinic.AnimalList){
        if(animal.Sex == 'F'){
            femaleSum += animal.Age;
            count++;
        }
    }
    if(count == 0){
        Console.WriteLine();
        Console.WriteLine("Sem Registro de Animais Fêmeas");
        GetBackToMenu();
    }

    average = femaleSum / count;
    Console.WriteLine($"MÉDIA: {average.ToString("F")} anos");

    GetBackToMenu();
}

void ChangeAddress(){
    Console.Clear();

    Console.WriteLine("||||| ALTERAÇÃO DE ENDEREÇO |||||");
    Console.WriteLine();
    Console.WriteLine($"Endereço atual: {clinic.Address}");
    Console.Write("Digite o novo endereço: ");
    clinic.Address = Console.ReadLine();

    Console.WriteLine();
    Console.WriteLine($"Endereço alterado para '{clinic.Address}'");

    GetBackToMenu();
}

void ClinicDetails(){
    Console.Clear();
    Console.WriteLine("------DETALHES DA CLÍNICA------");
    Console.WriteLine();
    Console.WriteLine($"Nome: {clinic.Name}");
    Console.WriteLine($"Endereço: {clinic.Address}");
    Console.WriteLine($"Animais Cadastrados: {clinic.AnimalList.Count()}");
    
    GetBackToMenu();
}

void ShowListAnimal(){
    Console.Clear();
    Console.WriteLine("-=-=-=-=-LISTA DE ANIMAIS-=-=-=-=-");
    Console.WriteLine();
    int cont = 1;
    foreach(var animal in clinic.AnimalList){
        Console.WriteLine($"ANIMAL {cont}\n{animal.Name}\n{animal.Species}\n{animal.Age} ano(s)\n{animal.Sex}\n");
        cont++;
    }
    if(cont == 1){
        Console.WriteLine("Sem Registro de Animais");
        GetBackToMenu();
    }

    GetBackToMenu();
}

void GetBackToMenu(){
    Console.WriteLine();
    Console.WriteLine("Aperte qualquer tecla para voltar ao Menu Principal");
    Console.ReadKey();
    Menu();
}
