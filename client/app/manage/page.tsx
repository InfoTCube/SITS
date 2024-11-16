import React, { Suspense } from "react"
import ListOfItems from "../../components/list-of-items"

const Home = () => {
  return (
    <Suspense fallback={"Loading..."}>
      <ListOfItems />
    </Suspense>
  )
}

export default Home