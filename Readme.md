# LemonInc.Core.Pooling

Object pooling system.

## Coming up...

Sorted by priority

1. ObjectPoolProvider editor
    > Being able to create pools from within the editor

1. Templated ObjectPoolProvider\<TKey>, the TKEY will define how the pools are stored
    > Being able to store pools by GameObject names, enums, types, ...

1. A new managing entity that allows to bind IPools to a set of scenes.
    > Being able to have scene related pools that get fully released on scene switch

1. Bunch of IPoolable implems in some LemonInc.Utilities.Pooling or whatever package to provide with quick features.
    > IdlePoolable => Just a poolable that sits there

    > ParticleSystemPoolable => Release to the pool when stopped playing
    
    > AudioSoucePoolable => Release to the pool when stopped playing