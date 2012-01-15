module GreedDiceScoringTests

open NaturalSpec
open GreedDiceScoring

let scored(dice) =
  score(dice)

[<Scenario>]
let ``When a single 1 rolled``() =
  Given [1] |> When scored |> It should equal 100 |> Verify

[<Scenario>]
let ``When a single 5 rolled``() =
  Given [5] |> When scored |> It should equal 50 |> Verify

[<Scenario>]
let ``When triple 1s rolled``() =
  Given [1;1;1] |> When scored |> It should equal 1000 |> Verify

[<Scenario>]
let ``When triple 2s rolled``() =
  Given [2;2;2] |> When scored |> It should equal 200 |> Verify

[<Scenario>]
let ``When triple 3s rolled``() =
  Given [3;3;3] |> When scored |> It should equal 300 |> Verify

[<Scenario>]
let ``When triple 4s rolled``() =
  Given [4;4;4] |> When scored |> It should equal 400 |> Verify

[<Scenario>]
let ``When triple 5s rolled``() =
  Given [5;5;5] |> When scored |> It should equal 500 |> Verify

[<Scenario>]
let ``When triple 6s rolled``() =
  Given [6;6;6] |> When scored |> It should equal 600 |> Verify

[<Scenario>]
let ``When four 2s rolled``() =
  Given [2;2;2;2] |> When scored |> It should equal 400 |> Verify

[<Scenario>]
let ``When four 1s rolled``() =
  Given [1;1;1;1] |> When scored |> It should equal 2000 |> Verify

[<Scenario>]
let ``When four 6s rolled``() =
  Given [6;6;6;6] |> When scored |> It should equal 1200 |> Verify

[<Scenario>]
let ``When three 1s and three 5s rolled``() =
  Given [1;1;1;5;5;5] |> When scored |> It should equal 1500 |> Verify

[<Scenario>]
let ``When five 1s rolled``() =
  Given [1;1;1;1;1] |> When scored |> It should equal 4000 |> Verify

[<Scenario>]
let ``When six 1s rolled``() =
  Given [1;1;1;1;1;1] |> When scored |> It should equal 8000 |> Verify

[<Scenario>]
let ``When three pairs are rolled``() =
  Given [2;2;3;3;4;4] |> When scored |> It should equal 800 |> Verify

[<Scenario>]
let ``When a straight is rolled``() =
  Given [1;2;3;4;5;6] |> When scored |> It should equal 1200 |> Verify