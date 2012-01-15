// Learn more about F# at http://fsharp.net

module GreedDiceScoring

let incCount index ( counts : array<int>) =
 counts.[index-1] <- counts.[index-1] + 1
 counts

let rec countWork dice (counts : array<int>) =
  match dice with
    | head :: tail -> countWork tail (incCount head counts)
    | [] -> counts

let count dice =
  countWork dice [|0;0;0;0;0;0|]

let rec scoreTuple x =
  match x with
  | (1, 1) -> 100
  | (1, 3) -> 1000
  | (x, 3) -> x * 100
  | (5, 1) -> 50
  | (x, 4) -> scoreTuple(x, 3) * 2
  | (x, 5) -> scoreTuple(x, 3) * 4
  | (x, 6) -> scoreTuple(x, 3) * 8
  | _ -> 0

let scoreCounts (c : array<int>) =
  let numPairs = (Array.filter (fun e -> e = 2) c).Length
  match numPairs with
  | 3 -> 800
  | _ -> 
      match c with
      | [|1;1;1;1;1;1|] -> 1200
      | _ ->
          scoreTuple (1, c.[0]) +
          scoreTuple (2, c.[1]) + 
          scoreTuple (3, c.[2]) +
          scoreTuple (4, c.[3]) + 
          scoreTuple (5, c.[4]) + 
          scoreTuple (6, c.[5])

let score dice =
  scoreCounts (count dice)