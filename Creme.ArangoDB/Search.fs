﻿namespace Creme.ArangoDB

module internal Search =
    open ArangoDB
    open Client
    open Helper
    open FSharp.Control.Tasks

    let GetSearch name =
        task {
            let! response = defaultConfig.Client.GetAsync(host [| "_api"; "view"; name |])

            return int response.StatusCode, emptyQueryResult
        }

    let CreateSearch record =
        task {
            let record: SearchOptions = record

            let! response = defaultConfig.Client.PostAsync(host [| "_api"; "view#arangosearch" |], serialize record)

            return int response.StatusCode, emptyQueryResult
        }
