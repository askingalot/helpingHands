open System

type Helper =
  { firstName: string
  ; lastName: string }

type PersonInNeed =
  { firstName: string
  ; lastName: string }

type NeedInfo =
  { description: string
  ; time: DateTime
  ; personInNeed: PersonInNeed }

type Need =
  | Unclaimed of NeedInfo
  | Claimed of NeedInfo * Helper

let claimNeed need helper =
  match need with
  | Unclaimed n -> Claimed (n, helper)
  | Claimed (n, h) -> failwithf "%s already claimed" n.description

let bob: PersonInNeed = { firstName = "Bob"; lastName = "Smith" }
let sue: Helper = { firstName = "Sue"; lastName = "Jones" }
let need = Unclaimed { description = "Bob needs a ride to the doctor";
                       time = DateTime(2015, 12, 30, 11, 0, 0);
                       personInNeed = bob }

let claimed = sue |> claimNeed need

printfn "%A" claimed


