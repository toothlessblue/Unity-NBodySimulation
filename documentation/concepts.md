[Read Me](../README.md)

## Concepts

- "Bodies" are objects that are pulled toward each other through gravity

### Rigidbodies
- Each `Body` component must be paired with a `Rigidbody` component, this is done automatically
- Bodies use the `mass` property of their rigidbodies in their gravity calculations
- Rigidbodies handle actual motion, whereas bodies handle acceleration