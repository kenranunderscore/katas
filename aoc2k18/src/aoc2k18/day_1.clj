(ns aoc2k18.day-1
  (:require [clojure.string :as string]))

(defn frequency
  [data]
  (->> data
       string/split-lines
       (map read-string)
       (apply +)))

(frequency (slurp "data/day-1"))
